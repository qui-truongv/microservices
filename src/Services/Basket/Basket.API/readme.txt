1. Get redis image:
    docker pull redis
    docker run -d -p 6379:6379 --name aspnetrun-redis redis
    docker logs -f aspnetrun-redis
    docker excec -it aspnetcun-redis /bin/bash