FROM mysql:5.7.22
EXPOSE 3306
COPY ./LibraryAPI/db/migrations/ /home/database/
COPY ./LibraryAPI/db/dataset/ /home/database/
COPY ./LibraryAPI/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh