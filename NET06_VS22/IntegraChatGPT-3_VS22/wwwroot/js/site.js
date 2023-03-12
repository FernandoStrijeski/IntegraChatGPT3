// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function enviar() {
    getConclusion(document.getElementById('txConsulta').value);
}

function getConclusion(question) {
    const url = `/api/getconclusion?question=${encodeURIComponent(question)}`;
    return fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao obter a conclusão');
            }
            return response.json();
        })
        .then(data => {
            const result = document.getElementById('txResposta');
            result.textContent = data.message.content;
        })
        .catch(error => console.error(error));
}