using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Xml.Linq;

namespace menu_lateral
{
    internal class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection ConexaoBanco()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            
            path = "Data Source=" + path + "student.db";

            conexao = new SQLiteConnection(path);
            conexao.Open();
            return conexao;
        }
        public static DataTable queryExecute(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            //para inserir registro
            //"INSERT INTO tabela (campo) values ('valor')"

            //para somar 
            //"select sum(id) from email"

            //para deletar
            //"DELETE FROM materias WHERE id = '3'"

            //deleta tabela e reinicia contagem id
            //delete from materias;
            //delete from sqlite_sequence where name = 'materias';

            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
