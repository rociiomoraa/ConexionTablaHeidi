using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ConexionTablaHeidi
{
    public partial class Form3 : Form
    {
        // ID del alumno que recibiremos desde Form1
        public int idAlumno;

        // ID de la nota cuando venimos a MODIFICAR
        public int idNota = -1;

        // Conexión a la BD
        private string conexionBD = "Server=localhost;Database=instituto;Uid=root;Pwd=1234;";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Si venimos a modificar, cargamos los datos de la nota
            if (idNota != -1)
            {
                CargarDatosNota();
                btnAñadir.Text = "Modificar";
            }
        }

        private void CargarDatosNota()
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                string sql = "SELECT asignatura, nota FROM notas WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idNota);

                var lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    textBoxAsignatura.Text = lector["asignatura"].ToString();
                    textBoxNota.Text = lector["nota"].ToString();
                }
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string asignatura = textBoxAsignatura.Text;
            string notaTexto = textBoxNota.Text;

            // Validación de campos
            if (string.IsNullOrWhiteSpace(asignatura) || string.IsNullOrWhiteSpace(notaTexto))
            {
                MessageBox.Show("Rellena todos los campos.");
                return;
            }

            // Validar si la nota es número
            if (!float.TryParse(notaTexto, out float nota))
            {
                MessageBox.Show("La nota debe ser un número.");
                return;
            }

            // Validar rango lógico
            if (nota < 0 || nota > 10)
            {
                MessageBox.Show("La nota debe estar entre 0 y 10.");
                return;
            }

            // Elegir si añadimos o modificamos
            if (idNota == -1)
            {
                InsertarNota(asignatura, nota);
            }
            else
            {
                ModificarNota(asignatura, nota);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InsertarNota(string asignatura, float nota)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                string sql = "INSERT INTO notas (id_alumno, asignatura, nota) VALUES (@alumno, @asig, @nota)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@alumno", idAlumno);
                cmd.Parameters.AddWithValue("@asig", asignatura);
                cmd.Parameters.AddWithValue("@nota", nota);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Nota añadida correctamente.");
        }

        private void ModificarNota(string asignatura, float nota)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                string sql = "UPDATE notas SET asignatura=@asig, nota=@nota WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@asig", asignatura);
                cmd.Parameters.AddWithValue("@nota", nota);
                cmd.Parameters.AddWithValue("@id", idNota);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Nota modificada correctamente.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Mantengo tu evento vacío tal como estaba
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
