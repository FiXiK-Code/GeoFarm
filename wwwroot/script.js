



const grid = document.querySelector('.grid');
let numRows = 4;
let numCols = 4;
let titles = [];


function createTile(title) {
        console.log("createTitle start");
    const tile = document.createElement('div');
    tile.classList.add('tile');
    if (title.length > 18) {
        tile.textContent = "..."
    } else {
        tile.textContent = title;
    }
    return tile;
}

function fillGrid() {
        console.log("fillGrid start");
    // определяем количество строк и столбцов
    const width = grid.clientWidth; // текущая ширина рабочей области
    console.log("width " + width);
    const height = window.outerHeight - 150;// текущая высота рабочей области
    console.log("height " + height);

    const tileWidth = 150; // ширина плашки
    const tileHeight = 100; // высота плашки
    const gap = 30; // расстояние между плашками
    const colsThatFit = Math.floor((width + gap) / (tileWidth + gap));
    console.log("colsThatFit " + colsThatFit);
    const rowsThatFit = Math.floor((height + gap) / (tileHeight + gap));
    console.log("rowsThatFit " + rowsThatFit);
    var numCols = Math.max(colsThatFit, 1); // так как minimum количество колонок равно 1
    console.log("numCols " + numCols);
    var numRows = Math.max(rowsThatFit, 1); // так как minimum количество строк равно 1
    console.log("numRows " + numRows);
    // получаем индексы заголовков, которые уже отображены в плашках на странице
    const tiles = Array.from(grid.children);
    console.log("children " + grid.children.length);
    console.log("tiles " + tiles.length);

    var tileIndices = [];
    if (tiles.length != 0) {
        tileIndices = tiles.map(tile => Number(tiles.indexOf(tile)));
    }
    


    console.log("tileIndices " + tileIndices);
    // определяем индексы заголовков, которые необходимо отобразить
    const startIndex = Math.max(...tileIndices, 0);
    console.log("startIndex " + startIndex);
    const endIndex = numCols * numRows;
    console.log("endIndex " + endIndex);

    const indicesToFetch = [];
    for (let i = startIndex; i < endIndex; i++) {
        console.log(!tileIndices.includes(i));
        if (!tileIndices.includes(i) && i != tileIndices[tileIndices.length - 1]) {
            indicesToFetch.push(i);
        }
    }
    if (tiles.length == 0) indicesToFetch.push(endIndex);

    console.log("indicesToFetch.length " + indicesToFetch.length);
    console.log("fillGrid if start");
    // загружаем недостающие заголовки и добавляем плашки на страницу
    if (indicesToFetch.length > 0) {
        fetch("/api/GetEmployees",
            {
                method: "post",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    startId: indicesToFetch[0],
                    endId: indicesToFetch[indicesToFetch.length-1]
                })
            })
            .then((response) => response.json())
            .then((data) => {
                newTitles = data.value.titles

                titles = titles.concat(newTitles); // добавляем заголовки в массив заголовков
                const fragment = document.createDocumentFragment();
                indicesToFetch.forEach(index => {
                    if (index < titles.length) {
                        const title = titles[index];
                        const tile = createTile(title);
                        tile.dataset.index = index;
                        fragment.appendChild(tile);
                    }
                });
                grid.appendChild(fragment); // добавляем плашки на страницу
                console.log("fillGrid if complit");
            });

            
    }

    console.log("fillGrid del titles--------------");
    // удаляем плашки, которые не влезают на страницу
    if (tiles.length != 0) {
        tiles.forEach(tile => {
            const index = Number(tiles.indexOf(tile));
            if (index >= endIndex || index >= titles.length) {
                grid.removeChild(tile);
                console.log("gridChild.Length " + grid.children.length);
            }
        });
    }
    

    console.log("fillGrid set size");
    // задаем размеры плашек и количество строк и столбцов сетки
    grid.style.gridTemplateColumns = `repeat(${numCols}, ${tileWidth}px)`;
    grid.style.gridTemplateRows = `repeat(${numRows}, ${tileHeight}px)`;
}

// вызываем функцию fillGrid при загрузке страницы и при изменении размера окна браузера
console.log("fetch fillGrid");
fillGrid();
window.addEventListener('resize', fillGrid);