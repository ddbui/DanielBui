# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
#!/usr/bin/env python3

def process(line, dict):     
    trainings = ("pluralsight", "infiniteskills", "teamtreehouse", "digitaltutors", "ostrainings", "tutsplus", "learnnowonline")
    
    # Search for those with "0x" and exclude them
    if not "0x" in line and "#" in line:
        line2 = line.replace("[ ", "[")
        #print(line2)
        
        # Need to do something like try... catch...
        try:
            month, date, time, user, slot, number, size, title = line2.split()
            user = user.replace("<", "")
            user = user.replace(">", "")
            title = title.replace(".tar", "")
            title = title.replace(".", " ")
            
            words = title.split()           

            dict[title] = "/msg {} xdcc send {}, {} {}".format(user, slot, size, number)
                
        except Exception:
            #print(line)
            pass    
        
        return dict
        
def write_to_file(keys, dict):        
    keys.sort()       
       
    with open("hexchat_output.txt", "w", encoding="utf8") as outfile:
        for key in keys:
            #print(key, dict[key])
            outfile.write(key + " " + dict[key] + "\n")
        
def main():      
    
    # Open and read a text file
    count = 0
    dict = {}
    with open ("C:/Users/Daniel/AppData/Roaming/HexChat/logs/Abjects/#beast-xdcc.log", encoding="utf8") as f:
        for line in f:
            count += 1
            tmp = line.lower()

            #training
#            if (not "pluralsight"       in tmp and
#                not "infiniteskills"    in tmp and
#                not "teamtreehouse"     in tmp and
#                not "digitaltutors"     in tmp and
#                not "ostrainings"       in tmp and
#                not "tutsplus"          in tmp and
#                not "learnnowonline"    in tmp and
#                not "lesson"            in tmp and
#                not "lynda"             in tmp):
                
            #software                
#            if (not "keymaker"          in tmp and
#                not "keygen"            in tmp):
    
            #if not "hdtv" in tmp:                

#            if not "bluray" in tmp or not "201" in tmp:
                
            if not ".xxx." in tmp:                                
                continue
            
            #year 2010 and after
#            if not "201" in tmp:
#                continue
            
            process(line, dict)            
            
    print("processed " + str(count) + " lines")            
    keys = list(dict.keys())    
    write_to_file(keys, dict)
            
#    for key, value in dict.items():
#        print(key, value)
        
if __name__ == "__main__":
    main()        

        
