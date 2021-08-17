#!/bin/bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P SApassword123! -d master -i /var/scripts/db-init.sql