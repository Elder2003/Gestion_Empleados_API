const API_URL = '/api/empleado';

async function cargarEmpleados() {
    try {
        const respuesta = await fetch(API_URL);
        const empleados = await respuesta.json();

        const cuerpoTabla = document.getElementById('tablaEmpleados');
        cuerpoTabla.innerHTML = '';

        empleados.forEach((emp, index) => {
            const fila = `
                <tr>
                    <td>#${emp.id}</td>
                    <td>
                        <div class="white-text">${emp.nombreCompleto}</div>
                        <span class="sub-text">Contrato Vigente</span>
                    </td>
                    <td>${emp.cargo}</td>
                    <td>${new Date(emp.fechaContrato).toLocaleDateString()}</td>
                    <td style="text-align: right;">Bs. ${emp.salario.toLocaleString()}</td>
                    <td style="text-align: right;">
                        <button class="btn-delete" onclick="eliminarEmpleado(${emp.id})">Baja</button>
                    </td>
                </tr>
            `;
            cuerpoTabla.innerHTML += fila;
        });
    } catch (error) {
        console.error("Error cargando datos:", error);
    }
}

document.getElementById('empleadoForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    const nuevoEmpleado = {
        id: 0,
        nombreCompleto: document.getElementById('nombre').value,
        cargo: document.getElementById('cargo').value,
        salario: parseFloat(document.getElementById('salario').value),
        fechaContrato: new Date().toISOString()
    };

    await fetch(API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(nuevoEmpleado)
    });
    document.getElementById('empleadoForm').reset();
    cargarEmpleados();
});

async function eliminarEmpleado(id) {
    if (confirm('¿Confirmar baja del empleado seleccionado?')) {
        await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
        cargarEmpleados();
    }
}

cargarEmpleados();