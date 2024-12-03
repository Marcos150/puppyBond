"use strict";
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Ejemplo de uso en boton: <button onclick="mostrarMensaje('Esto es el título', 'Esto es el mensaje', 'success');">Demo mensaje modal</button>
//Icono puede ser "success", "error", "warning", "info" o "question"
function mostrarMensaje(titulo, texto, icono = "info") {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: icono
    });
}