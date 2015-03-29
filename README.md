## Network Applications 

#### UDP time sharing

If you want to share your time on the other machine, run client and server executable files on your 
computers after creating network between them. This network does not require the internet connection, 
it's only necessary for LAN. The internet can also be connected, this WAN doesn't have any influences 
on the application. 

#### How it works

Client and server application creates their own sockets. Sockets can also be associated like transmitter 
and broadcaster in traditional radio. After that creates two nodes. The first node is binding to the socket, the
second will remote from client or server. The remote node should have broadcasting IP address. It's all adresses, which 
"listening" server port. You can use something like this: IPAddress.Broadcast or IPAddress.Parse("255.255.255.255).
If server will try to send data to broadcasting IP, all clients which listening server port can receive that information.

NOTE: UDP protocol do not guarantee the fact, that the data will be delivered to client.


Bug reports: There is one bug, when client can't receive data from server. It's maybe connected with busy port, but anyway...

#### TCP time sharing

If you want to share your time on the other machine, run client and server executable files on your 
computers after creating network between them. This network does not require the internet connection, 
it's only necessary for LAN. The internet can also be connected, this WAN doesn't have any influences 
on the application. 

#### How it works
Client and server application creates their own sockets. Socket binding to the local node and server begins listen all input connections using method listen(10), where 10 means queue of input queries. When client connecting to the server using method connect(remoteNode), server understands it and receive client's IP Adress and Post. Then current date encoding and encoded data sends out to remote node, where this data decoding back and displaying to the user console. After that server closing connection and begin listen other queries if they already have.
