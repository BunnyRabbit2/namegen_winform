BunnyNameGen
============

I design Magic: The Gathering cards occasionally and I found that I was mostly terrible at coming up with names 
for any legendary things or for organisation/kingdom/clan names. I used to use Chris Pound's site for bits and 
pieces but I didn't like waiting for the site to update it's list so I ported the scripts over to C# and dropped 
them into a simple WinForm.

By default, it will open Datasets/DatasetNames.txt and load any and all datasets from the names in there. It can 
also load a dataset through the file menu and that dataset will be tacked onto the end of the list.

Most of the datasets are from Chris Pound's site. One Exception is the Elvish name file which was pulled from a 
wikipedia page. The scripts I based my work on can also be found there (http://generators.christopherpound.com/)

Dataset Format
--------------

Each dataset is just a .txt file containing all the words separated by spaces and new lines. The program currently 
accepts no other form of dataset.

Provided datasets:

- Arabic (female names)
- Arabic (male names)
- Arabic (surnames)
- Basque (male names)
- Basque (female names)
- Celtic (female names)
- Celtic (male names)
- Cthulhoid
- Latvian (female names)
- Latvian (male names)
- Viking (female names)
- Viking (male names)
- Elvish
- TestData (Really just a list of popular male British names I used to test loading and other stuff)

The future of BunnyNameGen
--------------------------

At the moment there's nothing else I want to add but feel free to add whatever. Also feel free go about fixing stuff 
or laying it out differently.
