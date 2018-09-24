docker build -t idsrv .
docker run -p 8080:80 --name idsrv idsrv
docker container ls -f name=idsrv