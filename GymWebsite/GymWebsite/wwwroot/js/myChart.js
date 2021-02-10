var ctx = document.getElementByID('myChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Week 1', 'Week 2', 'Week 3', 'Week 4', 'Week 5', 'Week 6', 'Week 7', 'Week 8', 'Week 9', 'Week 10', 'Week 11', 'Week 12'],
        datasets: [{
            label: 'Will Bench Max (kg)',
            data: [100, 120, 135, 130, 135, 140, 145, 150, 150, 145, 160, 165],
            backgroundColor: [
                'rgba(0, 0, 0, 0.0)',
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
            ],
            borderWIDth: 3
            },
            {
                label: 'Jonny Bench Max (kg)',
                data: [110, 130, 135, 140, 145, 100, 135, 120, 150, 160, 170, 190],
                backgroundColor: [
                    'rgba(0, 0, 0, 0.0)',
                ],
                borderColor: [
                    'rgba(54, 162, 235, 1)',
                ],
                borderWIDth: 3
            },
            {
                label: 'Alex Bench Max (kg)',
                data: [90, 140, 145, 150, 135, 80, 115, 150, 160, 170, 200, 180],
                backgroundColor: [
                    'rgba(0, 0, 0, 0.0)',
                ],
                borderColor: [
                    'rgba(255, 206, 86, 1)',
                ],
                borderWIDth: 3
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
});