library(readr) # Required for reading csv
library(dplyr) # Required for filtering the dataset

# It might be better to use fread, according to this: https://rawgit.com/wiki/Rdatatable/data.table/vignettes/datatable-intro.html
# trainData is a data frame.
trainData <- read_csv("~/Projects/R/DataAnalysis/data/train.csv") 
#head(trainData)
View(trainData)

# Filter the data, e.g. WHERE Label = 1. Note that there're several way to filter data, e.g subset, filter, and []
#fault <- filter(trainData, Label == 1) 
#noFault <- filter(trainData, Label == 0)

fault <- trainData[trainData$Label == 1, ]
noFault <- trainData[trainData$Label == 0, ]

# Display certains columns, e.g. from FaultId to Count and 3 additional columns
# TODO: We can pass a string list/array to it?
fault$selected <- subset(fault, select = c(FaultId:Count, m_28V_Bus___RCM__V_, d_Airspeed_hold_on, m_Alt_MSL__ft_))

# TODO: Performs some calculation, e.g. average.
#meanFault <- colMeans(fault[10:30]) # WHAT EXACTLY THIS FUNCTION RETURNS? A DATAFRAME?
# What if I use apply(...), 2 is for column 
# Note that RStudio is displaying this in 2 columns while according to the book (Beginning R), we should see 2 rows.
# TODO: Try out with tapply(), sapply(), and lapply()
range <- 10:90

meanFault <- apply(fault[range], 2, mean) # applying "column mean" function to fault (from column 10 to 40) 
sdFault <- apply(fault[range], 2, sd) # applying "column standard deviation" function to fault (from column 10 to 40) 

meanNoFault <- apply(noFault[range], 2, mean)
sdNoFault <- apply(noFault[range], 2, sd)

# Combine all the data frames (?) that we've had so far into one view
df_result <- data.frame(cbind(meanNoFault, sdNoFault, meanFault, sdFault))
str(df_result)

# So, here we have 2 ways to add a "diff" column to our data frame. 
df_result$diff <- abs((df_result$meanFault - df_result$meanNoFault) / df_result$meanNoFault) * 100
#df_result <- transform(df_result, diff = round(abs((df_result$meanFault - df_result$meanNoFault) / df_result$meanNoFault) * 100, 3))

df_result <- df_result[df_result$diff >= 50 & is.finite(df_result$diff), ]

# Sort the data frame based on diff
df_result <- df_result[order(-df_result$diff),]
View(df_result)

sensors <- rownames(df_result)
View(sensors)

trainData$probFault <- 1.0
View(trainData)

#summaryFault <- apply(fault[range], 2, summary)
#View(summaryFault)

# Clean up
detach("package:readr", unload = TRUE)
detach("package:dplyr", unload = TRUE)
rm(list = ls())