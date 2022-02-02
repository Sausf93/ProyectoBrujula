#!/bin/sh
read -p $'\033[0;31mTHIS SCRIPT WILL RESET THE WHOLE DATABASE, CAUSING LOSS OF DATA!!\n\nARE YOU SURE? (Y/n): \033[0;33m' -n 1 -r
echo $'\033[0m '
if [[ $REPLY =~ ^[Yy]$ ]]
then
    dotnet ef database update 0 --project src/Infrastructure --startup-project src/Presentation
    dotnet ef migrations remove --project src/Infrastructure --startup-project src/Presentation
    dotnet ef migrations add Initial --project src/Infrastructure --startup-project src/Presentation --output-dir Persistence/Migrations
    dotnet ef database update --project src/Infrastructure --startup-project src/Presentation
fi