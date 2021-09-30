@echo off
echo Execute update scripts 

cd updates

for %%f in (*.*) do mysql -u "root" --password="asd123!1" "smokypet_db" < "%%f"

cd ..

echo End execute update scripts

pause