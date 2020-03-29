#### To achieve great things, two things are needed: a plan, and not quite enough time. – Leonard Bernstein


Personal offline day timer I use for completing tasks.

highlight the script below (triple click) and copy it, then paste it into the run command (winkey+r) to install:

`powershell -c "cd $home; wget https://github.com/macromaniac/dtimer/raw/master/dtimer.exe -outfile dtimer.exe;pause"`

now you can run command and type `dtimer 5` to get a 5 day countdown

`dtimer "do laundry" 5` would give you 5 days to do laundry (should be plenty)

![dtimer "do laundry" 5](src/example1.PNG)

The timer saves data, so running `dtimer` without arguments restores the last used timer if it exists

I typically put it on my second desktop (windowskey+tab, desktop 2) and leave the window open, as i dislike having lots of windows open on my work screen

### installation (alternate) ###

alternatively, [dl manually](https://github.com/macromaniac/dtimer/raw/master/dtimer.exe) and paste the exe into %HOMEPATH% (eg C:\Users\\(your username))
