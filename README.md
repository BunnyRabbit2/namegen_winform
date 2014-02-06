BunnyNameGen
============

I design Magic: The Gathering cards occasionally and I found that I was mostly terrible at coming up with names for any legendary things or for organisation/kingdom/clan names. I used to use Chris Pound's site for bits and pieces but I didn't like waiting for the site to update it's list so I ported the scripts over to C# and dropped them into a simple WinForm.

By default, it will open any xml in the XMLDatasets folder and any txt files found in the Datasets folder. XML datasets have priority and so a txt dataset with the same name as an XML dataset will NOT be loaded at all. It can also load a dataset through the file menu and that dataset will be tacked onto the end of the list.

Most of the datasets are from Chris Pound's site with a few added by myself. The scripts I based my work on can be found here: http://generators.christopherpound.com/

Dataset Format
--------------

Each dataset is either a simple xml file or a txt file containing all the words separated by spaces and new lines. The program currently accepts no other form of dataset.

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
- TestData
