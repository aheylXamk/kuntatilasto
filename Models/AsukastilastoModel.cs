using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ot7.Models {

    public class KuntaTieto {

        public string kunta {get; set;}
        public int asukkaatYhteensa {get; set;}
        public int asukkaatMiehet {get; set;}
        public int asukkaatNaiset {get; set;}

    }

    public class Asukastilasto {

        private string YhteysAsetukset {get;} = "server=localhost;user=root;password=;database=suomen_kunnat;SslMode=none";

        public List<KuntaTieto> haeKaikki() {

            try {

                using (MySqlConnection yhteys = new MySqlConnection(this.YhteysAsetukset)) {

                    yhteys.Open();

                    string SqlLause = "SELECT * FROM kunnat";

                    MySqlDataReader tulokset = new MySqlCommand(SqlLause, yhteys).ExecuteReader();

                    List<KuntaTieto> lista = new List<KuntaTieto>();

                    while (tulokset.Read()) {

                        string tulosKunta = tulokset.GetString("kunta");
                        int tulosYhteensa = tulokset.GetInt32("asukkaatYhteensa");
                        int tulosMiehet = tulokset.GetInt32("asukkaatMiehet");
                        int tulosNaiset = tulokset.GetInt32("asukkaatNaiset");

                        lista.Add(new KuntaTieto() {kunta=tulosKunta, asukkaatYhteensa=tulosYhteensa, asukkaatMiehet=tulosMiehet, asukkaatNaiset=tulosNaiset});

                    }

                    return lista;
                }
                    

            } catch (Exception e) {

                throw new Exception("Tietojen hakemisessa tapahtui virhe", e);
            }
        }

    public List<KuntaTieto> RajaaKunnat(int maara) {

        try {

                using (MySqlConnection yhteys = new MySqlConnection(this.YhteysAsetukset)) {

                    yhteys.Open();

                    string SqlLause = "SELECT * FROM kunnat LIMIT ?";

                    MySqlCommand kysely = new MySqlCommand(SqlLause, yhteys);

                    kysely.Parameters.Add("@maara", MySqlDbType.Int32);

                    kysely.Parameters["@maara"].Value = maara;

                    kysely.Prepare();

                    MySqlDataReader tulokset = kysely.ExecuteReader();

                    List<KuntaTieto> lista = new List<KuntaTieto>();

                        while (tulokset.Read()) {

                            string tulosKunta = tulokset.GetString("kunta");
                            int tulosYhteensa = tulokset.GetInt32("asukkaatYhteensa");
                            int tulosMiehet = tulokset.GetInt32("asukkaatMiehet");
                            int tulosNaiset = tulokset.GetInt32("asukkaatNaiset");

                            lista.Add(new KuntaTieto() {kunta=tulosKunta, asukkaatYhteensa=tulosYhteensa, asukkaatMiehet=tulosMiehet, asukkaatNaiset=tulosNaiset});

                    }

                    return lista;
                }
                    

            } catch (Exception e) {

                throw new Exception("Tietojen hakemisessa tapahtui virhe", e);
            }


        }

    public List<KuntaTieto> HaeKunta(string hakuehto) {

        try {

                using (MySqlConnection yhteys = new MySqlConnection(this.YhteysAsetukset)) {

                yhteys.Open();

                string SqlLause = "SELECT * FROM kunnat WHERE kunta = ?";

                MySqlCommand kysely = new MySqlCommand(SqlLause, yhteys);

                kysely.Parameters.Add("@hakuehto", MySqlDbType.VarChar);

                kysely.Parameters["@hakuehto"].Value = hakuehto;

                kysely.Prepare();

                MySqlDataReader tulokset = kysely.ExecuteReader();

                List<KuntaTieto> lista = new List<KuntaTieto>();

                while (tulokset.Read()) {

                    string tulosKunta = tulokset.GetString("kunta");
                    int tulosYhteensa = tulokset.GetInt32("asukkaatYhteensa");
                    int tulosMiehet = tulokset.GetInt32("asukkaatMiehet");
                    int tulosNaiset = tulokset.GetInt32("asukkaatNaiset");

                    lista.Add(new KuntaTieto() {kunta=tulosKunta, asukkaatYhteensa=tulosYhteensa, asukkaatMiehet=tulosMiehet, asukkaatNaiset=tulosNaiset});

                    }

                    return lista;
                }
                    

            } catch (Exception e) {

                throw new Exception("Tietojen hakemisessa tapahtui virhe", e);
            }


        }

    }

}