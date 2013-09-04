BunnyNameGen
============

A program that will generate names based on data given to it.

I design Magic: The Gathering cards occasionally and I found that I was mostly terrible at coming up with names 
for any legendary things. I used to use Chris Pound's site for bits an pieces but I didn't like waiting and needed 
a new project to take up some time to I decided to port the scripts he created over to C# and stick them in a 
program.

It currently uses the file DatasetNames.txt in the Datasets folder to load all other dataset files.

Most of the datasets are from Chris Pound's site. One Exception is the Elvish name file which was pulled from a 
wikipedia page. The scripts I based my work on can also be found there (http://generators.christopherpound.com/)

TODO
====

There is currently no way to load datasets outside of the default file. There is also an issue with displaying 
certain characters used in the cletic and elvish names.
