@echo off

call "sdkvars.bat"

gacutil -u DevExpress.Data.v7.3
gacutil -u DevExpress.Utils.v7.3

 
sn -Vr DevExpress.Data.v7.3.dll
gacutil -i DevExpress.Data.v7.3.dll
sn -Vu DevExpress.Data.v7.3.dll

sn -Vr DevExpress.Utils.v7.3.dll
gacutil -i DevExpress.Utils.v7.3.dll
sn -Vu DevExpress.Utils.v7.3.dll
