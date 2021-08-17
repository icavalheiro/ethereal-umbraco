import:
	docker-compose exec ethereal-umbraco-db sh /var/scripts/import-db-init.sh

up:
	docker-compose up

upd:
	docker-compose up -d

stop:
	docker-compose stop

in:
	docker-compose exec ethereal-umbraco-cms bash

in-db:
	docker-compose exec ethereal-umbraco-db bash
