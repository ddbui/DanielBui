# -*- coding: utf-8 -*-
"""
Spyder Editor


"""

#!/usr/bin/env python3
import sys
import numpy as np
import pandas as pd

input_file = 'train.csv'
output_file = 'output.csv'

# Tip 000: Reading CSF file using pandas
df = pd.read_csv(input_file)
#print(data_frame)
#df.to_csv(output_file, index=False)

# Tip 003: len(df.index) and len(df.columns) are the numbers of rows and columns respectively.
#print(len(df.index))
#print(len(df.columns))

#Tip 004: But using 'shape' might be a better way to get those numbers.
num_of_rows = df.shape[0]
num_of_cols = df.shape[1]
#print(num_of_rows)
#print(num_of_cols)

#Tip 006: How to filter rows in a data frame
bad_df = df[(df['Label'] == 1)]
#print(bad_df)
#Tip 007: This is to get a list of row and column names
#print(bad_df.index)
#print(bad_df.columns)

good_df = df[(df['Label'] == 0)]
#print(good_df)

#Tip 008: Get a subset for good_df and bad_df that exclude the first 9 columns
sub_bad_df = bad_df.ix[:,9:] # Get rows 0 to last and columns 9 to last.
#print(sub_bad_df)
sub_good_df = pd.DataFrame(good_df.ix[:,9:]) # Get rows 0 to last and columns 9 to last.
print(sub_good_df)

#Tip 009: Apply a function, e.g. mean, to the data frame.
good_means = sub_good_df.apply(np.mean)
print(good_means)

bad_means = sub_bad_df.apply(np.mean)
print(bad_means)

# Tip 001: Iterate over rows in a data frame
# Question: Why do we need "index" in the for loop? We don't even use it!
#for index, row in data_frame.iterrows():
    #Tip 005: This is how we access a particular cell.
    #print(row['Seq#'], row['FltDate'])
    
    #Tip 002: This is how we do the for loop from 9 to num_of_cols
    #for i in range(9, num_of_cols):                
        #print(i, df.columns[i], row[i])
    
