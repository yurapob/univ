#include <winsock2.h>
#include <stdio.h>
 
int main(void)
{
    WORD sockVer;
    WSADATA wsaData;
    int retVal;
    sockVer = MAKEWORD(2,2);
    WSAStartup(sockVer, &amp;wsaData);
    SOCKET servSock = socket(PF_INET, SOCK_STREAM, IPPROTO_TCP);
 
    if(servSock == INVALID_SOCKET)
    {
        printf("Unable to create socket\n");
        WSACleanup();
        return SOCKET_ERROR;
    }
    SOCKADDR_IN sin;
    sin.sin_family = PF_INET;
    sin.sin_port = htons(1111);
    sin.sin_addr.s_addr = INADDR_ANY;
 
    retVal = bind(servSock, (LPSOCKADDR)&amp;sin, sizeof(sin));
    if(retVal == SOCKET_ERROR)
    {
        printf("Unable to bind\n");
        WSACleanup();
        return SOCKET_ERROR;
    }
 
    retVal = listen(servSock, 10);
    if(retVal == SOCKET_ERROR)
    {
        printf("Unable to listen\n");
        WSACleanup();
        return SOCKET_ERROR;
    }

    SOCKET clientSock;
 
    clientSock = accept(servSock, NULL, NULL);
 
    if(clientSock == INVALID_SOCKET)
    {
        printf("Unable to accept\n");
        WSACleanup();
        return SOCKET_ERROR;
    }
 
    char szReq[8];
    retVal = recv(clientSock, szReq, 8, 0);
 
    if(retVal == SOCKET_ERROR)
    {
        printf("Unable to recv\n");
        return SOCKET_ERROR;
    }
 
    printf("Got the request from client\n%s\n",szReq);
 
    char *szResp = "Response";
 
    printf("Sending response from server\n");
    retVal = send(clientSock, szResp, strlen(szResp), 0);
 
    if(retVal == SOCKET_ERROR)
    {
        printf("Unable to send\n");
        return SOCKET_ERROR;
    }
 
    closesocket(clientSock);
    closesocket(servSock);
 
    WSACleanup();
    return 0;
}
