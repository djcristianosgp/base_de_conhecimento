SELECT RR.rdb$field_name AS Nome_Campo,
RR.RDB$RELATION_NAME AS Nome_Tabela,
RF.RDB$FIELD_LENGTH AS Tamanho,     
CASE RF.RDB$FIELD_TYPE     
WHEN 261 THEN 'BLOB' 
WHEN 14 THEN 'CHAR' 
WHEN 40 THEN 'CSTRING' 
WHEN 11 THEN 'D_FLOAT' 
WHEN 27 THEN 'DOUBLE' 
WHEN 10 THEN 'FLOAT' 
WHEN 16 THEN 'INT64' 
WHEN 8 THEN 'INTEGER' 
WHEN 9 THEN 'QUAD' 
WHEN 7 THEN 'SMALLINT' 
WHEN 12 THEN 'DATE' 
WHEN 13 THEN 'TIME' 
WHEN 35 THEN 'TIMESTAMP' 
WHEN 37 THEN 'VARCHAR' 
ELSE 'UNKNOWN' 
END AS Tipo
FROM RDB$RELATION_FIELDS RR 
join RDB$FIELDS RF ON RR.RDB$FIELD_SOURCE = RF.RDB$FIELD_NAME 
WHERE RR.rdb$field_name LIKE '%NATUREZA%';  
