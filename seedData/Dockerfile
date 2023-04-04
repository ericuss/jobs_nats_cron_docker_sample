FROM mongo

RUN apt-get update
RUN apt-get install dos2unix

COPY seedData/import.sh /import.sh
RUN dos2unix import.sh

COPY seedData/stores/ /stores/
COPY seedData/orders/ /orders/

ENTRYPOINT [ "/bin/bash", "import.sh" ]