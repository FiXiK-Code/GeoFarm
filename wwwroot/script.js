



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
    // ���������� ���������� ����� � ��������
    const width = grid.clientWidth; // ������� ������ ������� �������
    console.log("width " + width);
    const height = window.outerHeight - 150;// ������� ������ ������� �������
    console.log("height " + height);

    const tileWidth = 150; // ������ ������
    const tileHeight = 100; // ������ ������
    const gap = 30; // ���������� ����� ��������
    const colsThatFit = Math.floor((width + gap) / (tileWidth + gap));
    console.log("colsThatFit " + colsThatFit);
    const rowsThatFit = Math.floor((height + gap) / (tileHeight + gap));
    console.log("rowsThatFit " + rowsThatFit);
    var numCols = Math.max(colsThatFit, 1); // ��� ��� minimum ���������� ������� ����� 1
    console.log("numCols " + numCols);
    var numRows = Math.max(rowsThatFit, 1); // ��� ��� minimum ���������� ����� ����� 1
    console.log("numRows " + numRows);
    // �������� ������� ����������, ������� ��� ���������� � ������� �� ��������
    const tiles = Array.from(grid.children);
    console.log("children " + grid.children.length);
    console.log("tiles " + tiles.length);

    var tileIndices = [];
    if (tiles.length != 0) {
        tileIndices = tiles.map(tile => Number(tiles.indexOf(tile)));
    }
    


    console.log("tileIndices " + tileIndices);
    // ���������� ������� ����������, ������� ���������� ����������
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
    // ��������� ����������� ��������� � ��������� ������ �� ��������
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

                titles = titles.concat(newTitles); // ��������� ��������� � ������ ����������
                const fragment = document.createDocumentFragment();
                indicesToFetch.forEach(index => {
                    if (index < titles.length) {
                        const title = titles[index];
                        const tile = createTile(title);
                        tile.dataset.index = index;
                        fragment.appendChild(tile);
                    }
                });
                grid.appendChild(fragment); // ��������� ������ �� ��������
                console.log("fillGrid if complit");
            });

            
    }

    console.log("fillGrid del titles--------------");
    // ������� ������, ������� �� ������� �� ��������
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
    // ������ ������� ������ � ���������� ����� � �������� �����
    grid.style.gridTemplateColumns = `repeat(${numCols}, ${tileWidth}px)`;
    grid.style.gridTemplateRows = `repeat(${numRows}, ${tileHeight}px)`;
}

// �������� ������� fillGrid ��� �������� �������� � ��� ��������� ������� ���� ��������
console.log("fetch fillGrid");
fillGrid();
window.addEventListener('resize', fillGrid);