FROM mysql:latest
USER root
RUN chmod 755 /var/lib/mysql
COPY quotesdb.sql /docker-entrypoint-initdb.d/
ENV MYSQL_ROOT_PASSWORD=Test123456