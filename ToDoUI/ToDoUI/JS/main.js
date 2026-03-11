// --- SELECTORS ---
const cardInput = document.querySelector(".todo-input");
const cardBtn = document.querySelector(".todo-btn");
const board = document.querySelector("#board-container");
const search = document.querySelector("#search-input");

const standardBtn = document.querySelector(".standard-theme");
const lightBtn = document.querySelector(".light-theme");
const darkerBtn = document.querySelector(".darker-theme");

// --- TEMA MANTIĞI ---
let savedTheme = localStorage.getItem("savedTheme") || "standard";
changeTheme(savedTheme);

if (standardBtn) standardBtn.onclick = () => changeTheme("standard");
if (lightBtn) lightBtn.onclick = () => changeTheme("light");
if (darkerBtn) darkerBtn.onclick = () => changeTheme("darker");

function changeTheme(color) {
  localStorage.setItem("savedTheme", color);
  document.body.className = color;
  if (color === "light") {
    search.style.color = "#333";
    search.style.borderColor = "#333";
  } else {
    search.style.color = "white";
    search.style.borderColor = "rgba(255,255,255,0.5)";
  }
}

// --- MODERN CONFIRM ---
function modernConfirm(message, onConfirm) {
  const old = document.querySelector(".custom-confirm");
  if (old) old.remove();
  const div = document.createElement("div");
  div.className = "custom-confirm";
  div.innerHTML = `<p>${message}</p><div class="confirm-btns"><button class="btn-yes">Sil</button><button class="btn-no">Vazgeç</button></div>`;
  document.body.appendChild(div);
  setTimeout(() => div.classList.add("show"), 10);
  const close = () => {
    div.classList.remove("show");
    setTimeout(() => div.remove(), 400);
  };
  div.querySelector(".btn-yes").onclick = () => {
    onConfirm();
    close();
  };
  div.querySelector(".btn-no").onclick = close;
}

function askDeleteBoard(id, name) {
    if (typeof modernConfirm === 'function') {
        modernConfirm(`"${name}" kategorisini silmek istiyor musun?`, function () {
            window.location.href = '/Board/DeleteBoard/' + id;
        });
    }
}

// --- KAYDETME ---
function saveBoard() {
  const cards = [];
  document.querySelectorAll(".card").forEach((card) => {
    const title = card.querySelector("h3").innerText;
    const items = [];
    card.querySelectorAll(".todo-item").forEach((li) => {
      items.push({
        text: li.innerText,
        completed: li.closest(".todo").classList.contains("completed"),
      });
    });
    cards.push({ title, items });
  });
  localStorage.setItem("dd-board", JSON.stringify(cards));
}

// --- MADDE EKLEME ---
function addItemToList(list, text, isCompleted = false) {
  const toDoDiv = document.createElement("div");
  toDoDiv.className = `todo ${document.body.className}-todo ${isCompleted ? "completed" : ""}`;
  toDoDiv.setAttribute("draggable", "true");
  toDoDiv.innerHTML = `<li class="todo-item">${text}</li><div style="display: flex;"><button class="check-btn"><i class="fas fa-check"></i></button><button class="delete-btn"><i class="fas fa-trash"></i></button></div>`;
  toDoDiv.querySelector(".check-btn").onclick = () => {
    toDoDiv.classList.toggle("completed");
    saveBoard();
  };
  toDoDiv.querySelector(".delete-btn").onclick = () => {
    toDoDiv.classList.add("fall");
    toDoDiv.addEventListener("transitionend", () => {
      toDoDiv.remove();
      saveBoard();
    });
  };
  toDoDiv.addEventListener("dragstart", () =>
    toDoDiv.classList.add("dragging"),
  );
  toDoDiv.addEventListener("dragend", () => {
    toDoDiv.classList.remove("dragging");
    saveBoard();
  });
  list.appendChild(toDoDiv);
}

// --- KART OLUŞTURMA ---
function createCard(title, items = []) {
  const card = document.createElement("div");
  card.className = "card";
  card.innerHTML = `
        <div class="card-header" style="display:flex; justify-content:space-between; align-items:center; margin-bottom:10px;">
            <h3 style="margin:0; cursor:pointer;">${title}</h3>
            <button class="delete-card-btn" style="background:none; border:none; color:#e74c3c; cursor:pointer; font-size:1.5rem;">&times;</button>
        </div>
        <ul class="todo-list" style="min-height: 30px;"></ul>
        <div class="card-footer" style="display:flex; margin-top:10px; gap:5px;">
            <input type="text" class="item-in" placeholder="Ekle..." style="flex:1; padding:8px; border-radius:5px; border:none; color:#333;">
            <button class="item-add" style="border-radius:5px; border:none; padding:0 15px; cursor:pointer; background:#2ecc71; color:white;">+</button>
        </div>
    `;

  const list = card.querySelector("ul");
  const titleH3 = card.querySelector("h3");
  items.forEach((item) => addItemToList(list, item.text, item.completed));

  titleH3.onclick = () => {
    const currentTitle = titleH3.innerText;
    const input = document.createElement("input");
    input.type = "text";
    input.value = currentTitle;
    input.className = "edit-title-input";
    input.style.color = document.body.className === "light" ? "#333" : "white";
    titleH3.replaceWith(input);
    input.focus();
    const saveTitle = () => {
      const newTitle = input.value.trim() || currentTitle;
      titleH3.innerText = newTitle;
      input.replaceWith(titleH3);
      saveBoard();
    };
    input.onblur = saveTitle;
    input.onkeydown = (e) => {
      if (e.key === "Enter") saveTitle();
    };
  };

  card.querySelector(".delete-card-btn").onclick = () => {
    modernConfirm(
      `"${titleH3.innerText}" kategorisini silmek istiyor musun?`,
      () => {
        card.style.transform = "scale(0.8)";
        card.style.opacity = "0";
        setTimeout(() => {
          card.remove();
          saveBoard();
        }, 300);
      },
    );
  };

  card.querySelector(".item-add").onclick = () => {
    const input = card.querySelector(".item-in");
    if (input.value.trim()) {
      addItemToList(list, input.value);
      input.value = "";
      saveBoard();
    }
  };

  list.addEventListener("dragover", (e) => {
    e.preventDefault();
    const draggingItem = document.querySelector(".dragging");
    if (draggingItem) list.appendChild(draggingItem);
  });
  board.appendChild(card);
  saveBoard();
}

// --- ARAMA FONKSİYONU ---
// Sayfa yüklendiğinde arama kutusuna odaklanalım ve dinleyelim
document.addEventListener("keyup", function (e) {
    // Eğer yazılan yer bizim arama kutumuzsa
    if (e.target && e.target.id === "search-input") {

        // 1. Ne arıyoruz? (Küçük harfe çevir ve boşlukları at)
        const arananKelime = e.target.value.toLowerCase().trim();

        // 2. Sayfadaki tüm kartları bul
        const tumKartlar = document.querySelectorAll(".card");

        tumKartlar.forEach((kart) => {
            // 3. Kartın içindeki başlığı (H3) bul
            const baslikElementi = kart.querySelector("h3");

            if (baslikElementi) {
                const baslikMetni = baslikElementi.innerText.toLowerCase();

                // 4. Eğer başlık aranan kelimeyi içeriyorsa göster, içermiyorsa gizle
                if (baslikMetni.indexOf(arananKelime) > -1) {
                    // Tasarımı bozmamak için inline-block (çünkü senin kartlar yan yana)
                    kart.style.setProperty('display', 'inline-block', 'important');
                    kart.style.opacity = "1";
                } else {
                    kart.style.setProperty('display', 'none', 'important');
                }
            }
        });
    }
});

// Üstünü çizme ve DB güncelleme fonksiyonu
function toggleTask(btn, id) {
    // 1. Arayüzde anlık olarak üstünü çiz/kaldır
    const todoDiv = btn.closest('.todo');
    todoDiv.classList.toggle('completed');

    // 2. Arka planda Controller'ı tetikle (Status'u değiştir)
    fetch('/Board/ToggleCardStatus/' + id, { method: 'POST' })
        .then(response => {
            if (!response.ok) console.error("Güncelleme başarısız.");
        });
}



window.onload = () => {
  const savedData = localStorage.getItem("dd-board");
  if (savedData)
    JSON.parse(savedData).forEach((d) => createCard(d.title, d.items));
};