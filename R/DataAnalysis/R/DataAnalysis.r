library(readr) # Required for reading csv
library(dplyr) # Required for filtering the dataset

# trainData is a data frame.
trainData <- read_csv("~/Projects/GitHub/R/DataAnalysis/data/train.csv") 

fault <- trainData[trainData$Label == 1, ]
noFault <- trainData[trainData$Label == 0, ]

# Display certains columns, e.g. from FaultId to Count and 3 additional columns
# TODO: We can pass a string list/array to it?
fault$selected <- subset(fault, select = c(FaultId:Count, m_28V_Bus___RCM__V_, d_Airspeed_hold_on, m_Alt_MSL__ft_))

range <- 10:90

meanFault <- apply(fault[range], 2, mean) # applying "column mean" function to fault
sdFault <- apply(fault[range], 2, sd) # applying "column standard deviation" function to fault

meanNoFault <- apply(noFault[range], 2, mean)
sdNoFault <- apply(noFault[range], 2, sd)

# Combine all the data frames (?) that we've had so far into one view
result <- data.frame(cbind(meanNoFault, sdNoFault, meanFault, sdFault))
str(result)

# Add a "diff" column to our data frame. 
result$diff <- abs((result$meanFault - result$meanNoFault) / result$meanNoFault) * 100

# Filter to only include those with diff >= 50%
result <- result[result$diff >= 50 & is.finite(result$diff), ]

# Sort the data frame based on diff
result <- result[order(-result$diff),]
colnames(result) <- c("mean (no-fault)", "sd (no fault)", "mean (fault)", "sd (fault)", "abs % diff")
names(result) # colnames would work too!
str(result)
View(result)

# Get the displayed sensors
sensors <- rownames(result)
length(sensors)
str(sensors)

# My very first R function
calculateProbabilityFault <- function(x)
{
    return(x)
}

trainData$probFault <- calculateProbabilityFault(0.78)
View(trainData)

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