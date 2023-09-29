<?php
use Symfony\Component\Yaml\Yaml; //libreria che contiene i metodi per convertire YAML in JSON
$contenuto_file_yaml = file_get_contents('file.yaml');//salvo nella variabile il contenuto del file yaml

$contenuto_file_php = Yaml::parse($contenuto_file_yaml);//converto in un array php il contenuto yaml
//utilizza "Yaml::parse" per chiamare il metodo "parse" della classe "Yaml"  senza dover creare un'istanza dell'oggetto

$contenuto_file_json = json_encode($contenuto_file_php, JSON_PRETTY_PRINT);//converto l'array php in una stringa json
//json_encode è la funzione che ci ritorna una stringa contenente il file in json
echo $contenuto_file_json;//stampo a video contenuto_file_json
?>
