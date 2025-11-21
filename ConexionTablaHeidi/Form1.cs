using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ConexionTablaHeidi
{
    public partial class Form1 : Form
    {
        string conexionBD = "Server=localhost;Database=instituto;Uid=root;Pwd=1234;";

        private int alumnoSeleccionadoId = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                var comando = new MySqlCommand("SELECT * FROM alumnos", conexion);
                var lector = comando.ExecuteReader();

                float sumaNotas = 0;
                int cantidadNotas = 0;
                textBox1.Clear();

                while (lector.Read())
                {
                    textBox1.AppendText(lector["nombre"] + " " + lector["apellido"] + Environment.NewLine);

                    // ESTA LÍNEA ERA EL ERROR: LA COLUMNA nota YA NO EXISTE EN alumnos
                    // sumaNotas += Convert.ToSingle(lector["nota"]);
                    // cantidadNotas++;
                }

                label2.Text = "NOTA MEDIA: --";
            }

            CargarTabla();
            CargarAlumnos();
            CargarTodasLasNotas();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue?.ToString() ?? "";
        }

        private void CargarAlumnos()
        {
            var lista = new List<object>();

            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                var comando = new MySqlCommand("SELECT id, nombre, apellido FROM alumnos", conexion);
                var lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    lista.Add(new
                    {
                        Id = lector.GetInt32("id"),
                        Nombre = lector["nombre"] + " " + lector["apellido"]
                    });
                }
            }

            comboBox1.DataSource = lista;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
        }

        private void buttonAñadirAlumno_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            CargarAlumnos();
            CargarTabla();
            CargarTodasLasNotas();
        }

        // =====================
        //  TABLA CON MEDIA
        // =====================
        private void CargarTabla()
        {
            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                var adaptador = new MySqlDataAdapter("SELECT * FROM alumnos", conexion);
                var tabla = new DataTable();
                adaptador.Fill(tabla);

                // Crear la columna calculada "nota"
                if (!tabla.Columns.Contains("nota"))
                    tabla.Columns.Add("nota", typeof(string));

                foreach (DataRow fila in tabla.Rows)
                {
                    int idAlumno = Convert.ToInt32(fila["id"]);

                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT AVG(nota) FROM notas WHERE id_alumno=@id", conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", idAlumno);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                            fila["nota"] = Convert.ToDouble(result).ToString("0.00");
                        else
                            fila["nota"] = "--";  // antes ponías DBNull.Value (ERROR)
                    }
                }

                dataGridViewDatos.DataSource = tabla;
            }
        }

        private void dataGridViewDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dataGridViewDatos.Rows[e.RowIndex].Cells["id"].Value);

            Form2 f2 = new Form2();
            f2.alumnoId = id;
            f2.ShowDialog();

            CargarTabla();
            CargarAlumnos();
            CargarNotasPorAlumno(id);
            CalcularNotaMedia(id);
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un alumno primero.");
                return;
            }

            int id = Convert.ToInt32(dataGridViewDatos.SelectedRows[0].Cells["id"].Value);

            if (MessageBox.Show("¿Eliminar alumno?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();
                var comando = new MySqlCommand("DELETE FROM alumnos WHERE id=" + id, conexion);
                comando.ExecuteNonQuery();
            }

            CargarTabla();
            CargarAlumnos();
            CargarTodasLasNotas();
        }

        private void CargarTodasLasNotas()
        {
            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                var adaptador = new MySqlDataAdapter("SELECT * FROM notas", conexion);
                var tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridViewNotas.DataSource = tabla;
            }
        }

        private void CargarNotasPorAlumno(int alumnoId)
        {
            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                string consulta = "SELECT * FROM notas WHERE id_alumno = @id";
                var comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", alumnoId);

                var adaptador = new MySqlDataAdapter(comando);
                var tabla = new DataTable();
                adaptador.Fill(tabla);

                dataGridViewNotas.DataSource = tabla;
            }
        }

        private void dataGridViewDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            alumnoSeleccionadoId = Convert.ToInt32(
                dataGridViewDatos.Rows[e.RowIndex].Cells["id"].Value
            );

            CargarNotasPorAlumno(alumnoSeleccionadoId);
            CalcularNotaMedia(alumnoSeleccionadoId);
        }

        private void btnAñadirNota_Click(object sender, EventArgs e)
        {
            if (alumnoSeleccionadoId == -1)
            {
                MessageBox.Show("Selecciona un alumno primero.");
                return;
            }

            Form3 f3 = new Form3();
            f3.idAlumno = alumnoSeleccionadoId;

            if (f3.ShowDialog() == DialogResult.OK)
            {
                CargarNotasPorAlumno(alumnoSeleccionadoId);
                CalcularNotaMedia(alumnoSeleccionadoId);
                CargarTabla(); // refresca columna nota
            }
        }

        private void btnModificarNota_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una nota primero.");
                return;
            }

            int idNota = Convert.ToInt32(dataGridViewNotas.SelectedRows[0].Cells["id"].Value);
            int idAlumno = Convert.ToInt32(dataGridViewNotas.SelectedRows[0].Cells["id_alumno"].Value);

            Form3 f3 = new Form3();
            f3.idAlumno = idAlumno;
            f3.idNota = idNota;

            if (f3.ShowDialog() == DialogResult.OK)
            {
                CargarNotasPorAlumno(idAlumno);
                CalcularNotaMedia(idAlumno);
                CargarTabla();
            }
        }

        private void btnEliminarNota_Click(object sender, EventArgs e)
        {
            if (dataGridViewNotas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una nota primero.");
                return;
            }

            int idNota = Convert.ToInt32(dataGridViewNotas.SelectedRows[0].Cells["id"].Value);
            int idAlumno = Convert.ToInt32(dataGridViewNotas.SelectedRows[0].Cells["id_alumno"].Value);

            if (MessageBox.Show("¿Seguro que quieres eliminar esta nota?",
                                "Confirmación", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();
                string sql = "DELETE FROM notas WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idNota);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Nota eliminada correctamente.");

            CargarNotasPorAlumno(idAlumno);
            CalcularNotaMedia(idAlumno);
            CargarTabla();   // Refresca la media en la columna "nota"
        }


        private void CalcularNotaMedia(int alumnoId)
        {
            using (var conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                string sql = "SELECT AVG(nota) FROM notas WHERE id_alumno=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", alumnoId);

                object resultado = cmd.ExecuteScalar();

                if (resultado != DBNull.Value)
                    label2.Text = "NOTA MEDIA: " + Convert.ToDouble(resultado).ToString("0.00");
                else
                    label2.Text = "NOTA MEDIA: --";
            }
        }
    }
}
