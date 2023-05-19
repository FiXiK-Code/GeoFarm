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

    // ���������� ���������� ����� � �������� ��� �������� �����
    const width = grid.clientWidth;
    const height = window.outerHeight - 150;

    const colsCount = Math.floor((width + cardGap) / (cardWidth + cardGap));
    const rowsCount = Math.floor((height + cardGap) / (cardHeight + cardGap));

    var numCols = Math.max(colsCount, 1); 
    var numRows = Math.max(rowsCount, 1); 

    // �������� ������ �������� ������, ��� ������������ �� ��������
    const cards = Array.from(grid.children);

    var cardIndexes = [];
    if (cards.length != 0) {
        cardIndexes = cards.map(tile => Number(cards.indexOf(tile)));
    }
    
    // ���������� ������� ������, ������� ���������� ����������
    const startIndex = Math.max(...cardIndexes, 0);
    const endIndex = numCols * numRows;

    // ��������� �� ������ ���� ������ ������ ��� �������
    const cardIndexesToFetch = [];
    for (let i = startIndex; i < endIndex; i++) {
        if (!cardIndexes.includes(i) && i != cardIndexes[cardIndexes.length - 1]) {
            cardIndexesToFetch.push(i);
        }
    }
    if (cards.length == 0) cardIndexesToFetch.push(endIndex); // �������� �� ������ ��������, ��� ����������� ������� ���������� ������

    // ��������� ����������� ��������� � ��������� ������ �� ��������
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

                // ��������� ��������� �� ������� ������
                _cards = _cards.concat(newCards); 

                // ������� ������ ��� ��������� ��� � ������� �������
                const cardList = document.createDocumentFragment();

                cardIndexesToFetch.forEach(index => {
                    if (index < _cards.length) {
                        const title = _cards[index];
                        const cardFromResponse = createTile(title);
                        cardFromResponse.dataset.index = index;
                        cardList.appendChild(cardFromResponse);
                    }
                });

                grid.appendChild(cardList); // ��������� ������ �� ��������
            });

            
    }

    // ������� ������, ������� �� ������� �� ��������
    if (cards.length != 0) {
        cards.forEach(tile => {
            const index = Number(cards.indexOf(tile));
            if (index >= endIndex || index >= _cards.length) {
                grid.removeChild(tile);
            }
        });
    }
    

    // ������ ������� ������, ���������� ����� � ��������
    grid.style.gridTemplateColumns = `repeat(${numCols}, ${cardWidth}px)`;
    grid.style.gridTemplateRows = `repeat(${numRows}, ${cardHeight}px)`;
}

// ��������� ������ ��� �������� �������� � ��� ��������� ������� ���� ��������
insertGrid();
window.addEventListener('resize', insertGrid);