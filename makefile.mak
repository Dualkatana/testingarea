#$(mysql_config --libs) = -rdynamic -L/usr/lib/mysql -lmysqlclient -lz -lcrypt -lnsl -lm -L/usr/lib -lssl -lcrypto

#$(mysql_config --cflags) = -I/usr/include/mysql -g -pipe -Wp,-D_FORTIFY_SOURCE=2 -fexceptions -fstack-protector --param=ssp-buffer-size=4 -m32 -fasynchronous-unwind-tables -D_GNU_SOURCE -D_FILE_OFFSET_BITS=64 -D_LARGEFILE_SOURCE -fno-strict-aliasing -fwrapv

#Abhängigkeiten:
#main - server - Socket_UDP_linux - DatenPaket
#              - LogSystem
#              - MySQLmgr
#              - DatenPaket       - Koordinaten
#              - Koordinaten

server: LogSystem.o MySQLmgr.o Server.o Socket_UDP_linux.o DatenPaket.o Koordinaten.o main.o 
	g++ LogSystem.o MySQLmgr.o Server.o Socket_UDP_linux.o DatenPaket.o Koordinaten.o main.o -o UNITY_GAMESERVER $(mysql_config --libs)

main.o: main.cpp
	g++ -c $(mysql_config --cflags) main.cpp
	
LogSystem.o: LogSystem.cpp
	g++ -c LogSystem.cpp
	
MySQLmgr.o: MySQLmgr.cpp
	gcc -c $(mysql_config --cflags) MySQLmgr.cpp
	
Server.o: Server.cpp
	g++ -c $(mysql_config --cflags) Server.cpp
	
Socket_UDP_linux.o: Socket_UDP_linux.cpp
	g++ -c Socket_UDP_linux.cpp
	
DatenPaket.o: DatenPaket.cpp
	g++ -c DatenPaket.cpp
	
Koordinaten.o: Koordinaten.cpp
	g++ -c Koordinaten.cpp
	
clean:
	rm *.o
