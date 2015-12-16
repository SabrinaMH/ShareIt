echo "Provisioning Couchbase"
cd couchbase
vagrant up

echo "Provisioning EventStore"
cd eventstore
vagrant up