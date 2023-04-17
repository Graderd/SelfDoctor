// Obtener elementos del DOM
const abrirVentana = document.getElementById('abrirVentana');
const ventanaEmergente = document.getElementById('ventanaEmergente');
const sombraTrasera = document.createElement('div');
sombraTrasera.setAttribute('id', 'sombraTrasera');
const cancelar = document.getElementById('cancelar');

// Función para abrir la ventana emergente
function mostrarVentana() {
    ventanaEmergente.classList.remove('oculto');
    document.body.appendChild(sombraTrasera);
}

// Función para cerrar la ventana emergente
function ocultarVentana() {
    ventanaEmergente.classList.add('oculto');
    document.body.removeChild(sombraTrasera);
}

// Evento click para abrir la ventana emergente
abrirVentana.addEventListener('click', mostrarVentana);

// Evento click para cerrar la ventana emergente
cancelar.addEventListener('click', ocultarVentana);


