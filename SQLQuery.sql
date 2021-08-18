/*
* visualizzare i dati di tutti i passeggeri che sono stati controllati in ciascuno dei punti di dogana nell’arco della giornata; 
*/
SELECT pc.nome, p.nome, p.cognome, p.numero_documento 
FROM viaggi v
JOIN passeggeri p ON v.id_passeggero=p.id
JOIN punti_controlli pc ON v.id_punto_controllo=pc.id
WHERE CONVERT(date, v.data_inizio)=CONVERT(date, getdate()) 
ORDER BY pc.id

/*
* visualizzare per ciascun punto di controllo l’ammontare dei dazi doganali registrati; 
*/
SELECT pc.nome, SUM(v.dazio_doganale) AS dazio_doganale
FROM viaggi v
JOIN punti_controlli pc ON v.id_punto_controllo=pc.id
GROUP BY pc.nome

/*
* calcolare e visualizzare quante merci per ogni categoria sono state respinte dall’inizio dell’anno;
*/
SELECT cm.nome, SUM(m.quantita) AS n_merchi
FROM categorie_merchi cm
JOIN controllo_merchi m ON cm.id=m.id_categoria
JOIN viaggi v ON m.id_viaggio=v.id
WHERE m.id_esito=2 AND v.data_inizio>=DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0) 
GROUP BY cm.nome

/*
* calcolare e visualizzare quante contestazioni sono state registrate da ciascun addetto; 
*/
SELECT u.nome, u.cognome, COUNT(*) AS contestazioni
FROM utenti u
JOIN revisioni_controlli rc ON u.id=rc.id_utente
WHERE rc.id_motivazione=1
GROUP BY u.nome, u.cognome

/*
* calcolare la durata media dei controlli per ogni punto di controllo nell’arco della giornata;
*/
SELECT pc.nome, AVG(datediff(minute, v.data_inizio, v.data_fine)) AS media
FROM viaggi v
JOIN punti_controlli pc ON v.id_punto_controllo=pc.id
WHERE CONVERT(date, v.data_inizio)=CONVERT(date, getdate()) 
GROUP BY pc.nome

/*
* visualizzare l’elenco, in ordine alfabetico, raggruppato per nazionalità, dei passeggeri in 
* stato di fermo, registrati dall’inizio dell’anno in tutti i punti di controllo; 
*/
SELECT s.nome AS nazione, p.nome, p.cognome, p.numero_documento 
FROM viaggi v
JOIN passeggeri p ON v.id_passeggero=p.id
JOIN stati s ON p.id_nazione=s.id
WHERE v.data_inizio>=DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0) AND v.id IN(SELECT id_viaggio FROM controllo_merchi WHERE id_esito=3)
ORDER BY s.nome, p.nome, p.cognome

/*
* visualizzare gli addetti in servizio nella giornata; 
*/
SELECT u.nome, u.cognome 
FROM viaggi v
JOIN utenti u ON v.id_utente=u.id
WHERE CONVERT(date, v.data_inizio)=CONVERT(date, getdate()) 