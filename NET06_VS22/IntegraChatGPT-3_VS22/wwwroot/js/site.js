// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function enviarConversa() {
    getConclusion(document.getElementById('txConsulta').value);
}

function enviarAfinamento() {
    const resultAfinamento = document.getElementById('respostaAfinamento');
    const txAfinamento = document.getElementById('txAfinamento');
    importFineTune(txAfinamento.value)

    resultAfinamento.value = "";

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

function addFineTune(prompt, listaJson) {
    const url = `/api/addFineTune?prompt=${encodeURIComponent(prompt)}&listaJson=${encodeURIComponent(listaJson)}`;
    return fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao alimentar o fine tuning.');
            }
            return response.json();
        })
        .then(data => {
            const result = document.getElementById('txResposta');
            result.textContent = data.message.content;
        })
        .catch(error => console.error(error));
}

function importFineTune(prompts) {
    const url = `/api/importFineTune?prompts=${encodeURIComponent(prompts)}`;
    return fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao importar o fine tuning.');
            }
            return response.json();
        })
        .then(data => {
            const result = document.getElementById('respostaAfinamento');
            result.textContent = data.message.content;
        })
        .catch(error => console.error(error));
}