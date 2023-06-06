COMMAND PROMPT
cd /d d:\Library\REPOSITORY

git init: initializes current directory as LOCAL git repo
git status: shows what you have in staging area
git add <files>: specify file you want added
git add .: add all files
git commit: commits files in staging area to LOCAL repo
git commit -m "message": adds message to commit change
git push: takes local and pushes to remote (GitHub)
git pull: pulls latest changes from remote repo
git clone: clone repo from GitHub
git branch -b: lists remote branches
git checkout -b main: switches to main branch


ORDER:

git status: check to see if anything has been modified
git add .: add all files to staging area
git commit: add all files to local repo
git status: check status again to ensure all files were added
git push -u origin main: push all files to remote repo main branch


FIRST TIME:
After commit, do:
git branch -M main
git remote add origin https://github.com/NathanielWeissinger/Portfolio.git