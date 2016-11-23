library(readr) # Required for reading csv
library(dplyr) # Required for filtering the dataset

# trainData is a data frame.
trainData <- read_csv("~/Projects/GitHub/R/DataAnalysis/data/train.csv") # How do I use stringsAsFactors with this function? 
is.data.frame(trainData)

# This is called subsetting! (Not filtering?)
fault <- trainData[trainData$Label == 1, ]
noFault <- trainData[trainData$Label == 0, ]
is.data.frame(fault)

# Display certains columns, e.g. from FaultId to Count and 3 additional columns
# TODO: We can pass a string list/array to it?
fault$selected <- subset(fault, select = c(FaultId:Count, m_28V_Bus___RCM__V_, d_Airspeed_hold_on, m_Alt_MSL__ft_))

range <- 10:90

meanFault <- apply(fault[range], 2, mean) # applying "column mean" function to fault
sdFault <- apply(fault[range], 2, sd) # applying "column standard deviation" function to fault

meanNoFault <- apply(noFault[range], 2, mean)
sdNoFault <- apply(noFault[range], 2, sd)

# Combine all the data frames (?) that we've had so far into one view
#It's a common mistake to do cbind here! 
#bayes <- data.frame(cbind(meanNoFault, sdNoFault, meanFault, sdFault), stringsAsFactors = FALSE)
bayes <- data.frame(meanNoFault, sdNoFault, meanFault, sdFault, stringsAsFactors = FALSE)
str(bayes)

# Add a "diff" column to our data frame. 
bayes$diff <- abs((bayes$meanFault - bayes$meanNoFault) / bayes$meanNoFault) * 100

# Filter to only include those with diff >= 50%
bayes <- bayes[bayes$diff >= 50 & is.finite(bayes$diff), ]

# Sort the data frame based on diff
#bayes <- bayes[order(-bayes$diff),]
bayes <- bayes[order(bayes$diff, decreasing = TRUE), ]

colnames(bayes) <- c("mean (no-fault)", "sd (no fault)", "mean (fault)", "sd (fault)", "abs % diff")
names(bayes) # names and colnames are actually the same thing!

rownames(bayes)
bayes["d_GCU_inhibit", ]
bayes["d_GCU_inhibit", , drop = F]
bayes$d_GCU_inhibit
bayes[["d_GCU_inhibit"]]

str(bayes)
View(bayes)


# Get the displayed sensors
sensors <- rownames(bayes)
length(sensors)
str(sensors)

# My very first R function
loopTrainData <- function(x)
{
    # Looks like we'll need another apply here :)
    sapply(x[10:11], print)
    #print(x[1:3])
}

#trainData$probFault <- calculateProbabilityFault(0.78)
View(trainData)
apply(trainData, 1, loopTrainData)

loopBayes <- function(x)
{
  print(x)
}
#apply(bayes, 1, loopBayes)

bayes[] <- lapply(bayes[1:2], loopBayes)
str(bayes)

#for (data in trainData){
#  print(data)
#}
  
# There doesn't seems to be a different between the following 2 statements
# print(trainData)
# trainData

#trainData[1]   # Display the first column
#trainData[1,]  # Display the first row
#trainData[1,][5] # Display cell [1,5]

#rownames(trainData)

# Clean up
detach("package:readr", unload = TRUE)
detach("package:dplyr", unload = TRUE)
rm(list = ls())