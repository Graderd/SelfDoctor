function dibujarGraficoDiabetes() {

    $.ajax({
        url: "/DiabetesDiagnostic/GetLastDiabetesDiagnostic",
        method: "GET",
        contentType: "application/json",
        success: function (response) {
            const labels = [];
            const values = [];
            for (let label in response) {
                if (label !== 'id' && label !== 'userId' &&  label !== 'comment' && label !== 'date') {
                    labels.push(label);
                    values.push(response[label]);
                }
            }

            const lastDiagnosticDiabetesCanvas = document.getElementById("lastDiagnosticDiabetesGraphic").getContext('2d');


            const diabetesGraphicConfig = {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Ultimo resultado de diagnostico de diabetes',
                        data: values,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            };

            const diabetesChart = new Chart(lastDiagnosticDiabetesCanvas, diabetesGraphicConfig);
        }
    })

    

   

}

function dibujarGraficoHepatitis() {

    $.ajax({
        url: "/HepatitisDiagnostic/GetLastHepatitisDiagnostic", 
        method: "GET",
        contentType: "application/json",
        success: function (response) {
            const labels = [];
            const values = [];
            for (let label in response) {
                if (label !== 'id' && label !== 'category' && label !== 'userId' && label !== 'gendenId' && label !== 'categoryId' && label !== 'gender' && label !== 'comment' && label !== 'date') {
                    labels.push(label);
                    values.push(response[label]);
                }
            }


            const lastDiagnosticHepatitisCanvas = document.getElementById("lastDiagnosticHepatitisGraphic").getContext('2d');

            const hepatitisGraphicConfig = {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Ultimo resultado de diagnostico de Hepatitis',
                        data: values,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)'
                        ],
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            };

            const hepatitisChart = new Chart(lastDiagnosticHepatitisCanvas, hepatitisGraphicConfig);
        }
    })

}

function dibujarGraficoCancer() {

    $.ajax({
        url: "/BreastCancerDiagnostic/GetLastBreastCancerDiagnostic",
        method: "GET",
        contentType: "application/json",
        success: function (response) {
            const labels = [];
            const values = [];
            for (let label in response) {
                if (label !== 'id' && label !== 'userId' && label !== 'comment' && label !== 'date' && label !== 'breastCancerDiagnosisId' && label !== 'breastCancerDiagnosis') {
                    labels.push(label);
                    values.push(response[label]);
                }
            }

            const lastDiagnosticCancerCanvas = document.getElementById("lastDiagnosticCancerGraphic").getContext('2d');

            const cancerGraphicConfig = {
                type: 'bar',
                data: {
                    labels: labels,
                        datasets: [{
                        label: 'Ultimo resultado de diagnostico de Hepatitis',
                        data: values,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 159, 64, 0.2)',
                            'rgba(255, 99, 132, 0.2)'
                        ],
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            };

            const cancerChart = new Chart(lastDiagnosticCancerCanvas, cancerGraphicConfig);
            


           
        }
    })

    

}


dibujarGraficoDiabetes();
dibujarGraficoHepatitis();
dibujarGraficoCancer();