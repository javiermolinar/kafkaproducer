# kafkaproducer
A simple .net core kafka publisher

# How to start

- Download Kafka code
- Start the ZooKeeper
.\zookeeper-server-start.bat ..\..\config\zookeeper.properties
- Start Kafka Server
.\kafka-server-start.bat  ..\..config/server.properties
- Create some topics
 bin/kafka-topics.sh --create --zookeeper localhost:2181 --replication-factor 1 --partitions 1 --topic test