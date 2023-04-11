function dibujarGraficoDiabetes() {

    const lastDiagnosticDiabetesCanvas = document.getElementById("lastDiagnosticDiabetesGraphic").getContext('2d');

    const diabetesGraphicConfig = {
        type: 'bar',
        data: {
            labels: ["Pregnancies", "Glucose", "BloodPressure", "SkinThickness", "Insulin", "BMI", "DiabetesPedigreeFunction"],
            datasets: [{
                label: 'Ultimo resultado de diagnostico de diabetes',
                data: [6, 148, 72, 35, 0, 33.6, 0.627],
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

function dibujarGraficoHepatitis() {

    const lastDiagnosticHepatitisCanvas = document.getElementById("lastDiagnosticHepatitisGraphic").getContext('2d');

    const hepatitisGraphicConfig = {
        type: 'bar',
        data: {
            labels: ["Category", "ALB", "ALP", "ALT", "AST", "BIL", "CHE", "CHOL", "CREA", "GGT", "PROT"],
            datasets: [{
                label: 'Ultimo resultado de diagnostico de Hepatitis',
                data: [0, 38.5, 52.5, 7.7, 22.1, 7.5, 6.93, 3.23, 106.0, 12.1, 69.0],
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

function dibujarGraficoCancer() {

    const lastDiagnosticCancerCanvas = document.getElementById("lastDiagnosticCancerGraphic").getContext('2d');

    const cancerGraphicConfig = {
        type: 'bar',
        data: {
            labels: ["radio promedio", "textura media", "perímetro medio", "area media", "suavidad media", "compacidad media", "concavidad media", "puntos cóncavos significantivos", "media de simetria", "dimensión fractal media", "radio se", "textura se", "perímetro se", "area se", "suavidad se", "compacidad se", "concavidad se", "puntos cóncavos se", "simetría se", "dimensiones fractales se", "mal radio", "mala textura", "mal perímetro", "peor zona", "mala suavidad", "mala compacidad", "mala concavidad", "malos puntos cóncavos", "mala simetría", "mala dimensión fractal"],
            datasets: [{
                label: 'Ultimo resultado de diagnostico de Hepatitis',
                data: [0, 38.5, 52.5, 7.7, 22.1, 7.5, 6.93, 3.23, 106.0, 12.1, 69.0],
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


dibujarGraficoDiabetes();
dibujarGraficoHepatitis();
dibujarGraficoCancer();