const grid = document.querySelector('.grid');
const cardWidth = 150;
const cardHeight = 100;
const cardGap = 30;
let _cards = [];

function createTile(title) {
    const card = document.createElement('div');
    card.classList.add('tile');

    if (title.length > 18) {
        card.textContent = "..."
    }
    else {
        card.textContent = title;
    }

    return card;
}

function insertGrid() {

    // определяем количество строк и столбцов для разметки сетки
    const width = grid.clientWidth;
    const height = window.outerHeight - 150;

    const colsCount = Math.floor((width + cardGap) / (cardWidth + cardGap));
    const rowsCount = Math.floor((height + cardGap) / (cardHeight + cardGap));

    var numCols = Math.max(colsCount, 1); 
    var numRows = Math.max(rowsCount, 1); 

    // получаем массив индексов плашек, уже отображенных на странице
    const cards = Array.from(grid.children);

    var cardIndexes = [];
    if (cards.length != 0) {
        cardIndexes = cards.map(tile => Number(cards.indexOf(tile)));
    }
    
    // определяем индексы плашек, которые необходимо отобразить
    const startIndex = Math.max(...cardIndexes, 0);
    const endIndex = numCols * numRows;

    // заполняем на основе этих данных массив для запроса
    const cardIndexesToFetch = [];
    for (let i = startIndex; i < endIndex; i++) {
        if (!cardIndexes.includes(i) && i != cardIndexes[cardIndexes.length - 1]) {
            cardIndexesToFetch.push(i);
        }
    }
    if (cards.length == 0) cardIndexesToFetch.push(endIndex); // проверка на пустую страницу, для отображения четного количества плашек

    // загружаем недостающие заголовки и добавляем плашки на страницу
    if (cardIndexesToFetch.length > 0) {

        fetch("/api/GetTitles",
            {
                method: "post",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    startId: cardIndexesToFetch[0],
                    endId: cardIndexesToFetch[cardIndexesToFetch.length-1]
                })
            })
            .then((response) => response.json())
            .then((data) => {
                newCards = data.value.titles

                // добавляем заголовки во внешний массив
                _cards = _cards.concat(newCards); 

                // создаем массив для включения его в рабочую область
                const cardList = document.createDocumentFragment();

                cardIndexesToFetch.forEach(index => {
                    if (index < _cards.length) {
                        const title = _cards[index];
                        const cardFromResponse = createTile(title);
                        cardFromResponse.dataset.index = index;
                        cardList.appendChild(cardFromResponse);
                    }
                });

                grid.appendChild(cardList); // добавляем плашки на страницу
            });

            
    }

    // удаляем плашки, которые не влезают на страницу
    if (cards.length != 0) {
        cards.forEach(tile => {
            const index = Number(cards.indexOf(tile));
            if (index >= endIndex || index >= _cards.length) {
                grid.removeChild(tile);
            }
        });
    }
    

    // задаем размеры плашек, количество строк и столбцов
    grid.style.gridTemplateColumns = `repeat(${numCols}, ${cardWidth}px)`;
    grid.style.gridTemplateRows = `repeat(${numRows}, ${cardHeight}px)`;
}

// обновляем данные при загрузке страницы и при изменении размера окна браузера
insertGrid();
window.addEventListener('resize', insertGrid);