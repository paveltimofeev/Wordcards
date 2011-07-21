**What WordCards is**
--------------------------

This project is implementation of cards method for learning foreign words. It's implemented as Vista style gadget for OS Windows.

In difference of paper version, this system allows you to consist your own set of cards and to link each card with concrete context (sentance). It helps to remember how to use word correctly. Every card has a rank that descrides how many mistakes you did (cause of this low-ranked cards are well known and will be shown rarely).
Also, it has Play mode, in which window will be displayed on top in different timespan with different wordcard.

You can share your set of wordcards with friends. Just export it to xml file. This also support export to fb2 (for read cards at bookreader) or HTML files.

This solution uses MVP pattern and consist of several projects, including different realisations of view tier. Bellow you can see screenshot of WPF-based gadget.

![Wordcards gadget printscreen](https://github.com/paveltimofeev/Wordcards/raw/master/Screenshot.jpg)

It can be runned at OS Microsoft Windows XP / Vista / Win7 with Microsoft .NET Framework 4.0.

**Whats new or history of changes**
--------------------------

- [BUG] New card had 0 rank, now "Wordcards Stack Gadget.exe.Config" file has parameter DefaultRank that contains a default value of rank for new Card.
- Wordcards Stack Gadget remembers itself size and position
- Added combobox with specefic transcription symbols, you also can modify this list with "Symbols" parameter of "Wordcards Stack Gadget.exe.Config" configuration file.
- Completed some corrections in user interface (such as border colors of textbox). 
- Added scalability for the words textboxes (as test)
- Added context menu for title
