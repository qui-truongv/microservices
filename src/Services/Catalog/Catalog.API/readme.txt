1. Create compose file.
   Right click to Catalog.API > Add > Container Orchistrator Support
   
2. Edit docker-compose.yml and docker-compose.overrides.yml files

3. Run command to start containers:
   docker-compose -f .\docker-compose.yml -f .\docker-compose.overrides.yml up -d
   
4. Run command to recheck containers runing:
   docker ps

5. Runcommand to stop docker-compose:
   docker-compose -f .\docker-compose.yml -f .\docker-compose.overrides.yml down

6. Run commands to remove all:
   docker stop $(docker ps -aq)
   docker rm $(docker ps -aq)
   docker rmi $(docker images -q)