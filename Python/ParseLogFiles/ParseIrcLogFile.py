# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
#!/usr/bin/env python3
import datetime

def process(line, dict2, search_items):
    
    search_terms = ("pluralsight", "lynda", "tutsplus", "infiniteskills",
                    "ebook",
                    "bluray")
    
    # Not a line that we want to parse        
    if not "#" in line:
        return
        
    test_line = line.lower()        

    # There are some materials that we're not interested in!
    none_available  = "0x" in test_line
    hdtv            = "hdtv" in test_line or "[mg]-tv" in test_line
    bdrip           = "bdrip" in test_line
    non_english     = "german" in test_line
    dvdrip          = "dvdrip" in test_line and not "xxx" in test_line
    xvid            = "xvid" in test_line and not "xxx" in test_line
    divx            = "divx" in test_line and not "xxx" in test_line
    webrip          = "webrip" in test_line and not "xxx" in test_line
    webdl           = "web-dl" in test_line and not "xxx" in test_line
    french_shit     = "l.equipe" in test_line or "la.libre.belgique" in test_line or \
                      "la.gazzetta" in test_line or "le.figaro" in test_line or \
                      "le.monde" in test_line or "le.parisien" in test_line or "les.echos" in test_line
    
    if (none_available or hdtv or bdrip or non_english or 
        dvdrip or xvid or divx or webrip or webdl or
        french_shit):
        return

    line = line.replace("[ ", "[")    

    try:
        words = line.split()
        num_words = len(words)
        
        if num_words < 8:
            return
            
        number = words[5]
        number = number.replace("x", "")
        if number == "0":
            return
            
        slot = words[4]
            
        user = words[3]
        user = user.replace("<", "")
        user = user.replace(">", "")
        
        size = words[6]
        
        title = ''.join(words[7:num_words])                   
        title = title.replace(".tar", "")
        title = title.replace(".", " ")
        displayed_title = title
        title = title.replace("-", " ")
        title = title.lower()
        
        #dict2[displayed_title] = "{} {}, /msg {} xdcc send {}".format(size, number, user, slot)
        
        for term in search_terms:
            if term in title:
                search_items["{}: {}".format(term, displayed_title)] = "{} {}, /msg {} xdcc send {}".format(size, number, user, slot)
            
    except Exception:
        print("EXCEPTION: ", line)
        pass    
    
    return dict2
        
# Writes results to an output file
def write_to_file(input_file, channel, date, keys, dict2):        
    keys.sort()       

    output_file = "hexchat_output_{0}_{1}.txt".format(channel, date)
    with open(output_file, "w", encoding="utf8") as outfile:
        outfile.write(input_file + "\n")
        
        for key in keys:            
            
            try:
                outfile.write(key + " " + dict2[key] + "\n")

            except Exception:
                print("EXCEPTION: ", key)
                continue
            
def process_file(network, channel, date, search_items):
    count = 0
    dict2 = {}
    
    input_file = "C:\\Users\\Daniel\\AppData\\Roaming\\HexChat\\logs\\{0}\\{1}\\#{2}.log".format(network, date, channel)
    
    with open (input_file, encoding="utf8") as f:
        # for loop in python is slow, so avoid it if we can!
        for line in f:
            count += 1
            process(line, dict2, search_items)            
            
    print("processed " + str(count) + " lines")            
    keys = list(dict2.keys())    
    write_to_file(input_file, channel, date, keys, dict2)            
        
# Main function
def main():
    
    # Open and read a text file
    now = datetime.datetime.now()
    date = "{0}-{1:02d}-{2:02d}".format(now.year, now.month, now.day)
    
    search_items = {}
    
    process_file("Abandoned", "PORN-HQ", date, search_items)
    process_file("Abandoned", "warez", date, search_items)
    process_file("Abandoned", "ZOMBIE-WAREZ", date, search_items)
    
    process_file("Abjects", "beast-xdcc", date, search_items)
    process_file("Abjects", "MOVIEGODS", date, search_items)
    
    #process_file("AlphaIrc", "masterwarez", date, search_items)
    
    process_file("Criten", "0day-mp3s", date, search_items)
    process_file("Criten", "Batcave", date, search_items)
    process_file("Criten", "ELITEWAREZ", date, search_items)
    process_file("Criten", "masterwarez", date, search_items)
    process_file("Criten", "the-future", date, search_items)
    
    process_file("Frozyn", "BLACKMARKET-MUSIC", date, search_items)
    process_file("Frozyn", "blackmarket-warez", date, search_items)
    
    process_file("Iarec", "ULTRA-WAREZ", date, search_items)
    
    process_file("Rizon", "ELITEWAREZ", date, search_items)
    
    process_file("Scenep2p", "THE.SOURCE", date, search_items)
    
    process_file("Xerologic", "mp3", date, search_items)
    process_file("Xerologic", "warez", date, search_items)
    
    
    keys = list(search_items.keys())
    keys.sort()
    output_file = "Output\\hexchat_output_search_items.txt"
    with open(output_file, "w", encoding="utf8") as outfile:        
        for key in keys:
            
            try:
                outfile.write("{}, {}\n".format(key, search_items[key]))

            except Exception:
                print("EXCEPTION: ", key)
                continue    


# This is one of the best practices!
if __name__ == "__main__":
    main()