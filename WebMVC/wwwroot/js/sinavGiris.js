var index = 0;
kontrol = 0;
var divBaslat = document.getElementById("baslatDivi");
var sayfalar = new Array();
function basla(btn) {
    if (kontrol == 0) {
        kontrol++;
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                let result = JSON.parse(xhr.responseText);
                var kategoriler = Array.from(result);
                for (var i = 0; i < kategoriler.length; i++) {
                    //var k = 0;
                    var dizi = [];
                    dizi.push(0);
                    var kapak = yeniDiv();
                    var baslik = yeniDiv();
                    baslik.innerText = kategoriler[i].kategoriAdi;
                    baslik.className = "baslikKapak";
                    kapak.appendChild(baslik);
                    sayfalar.push(kapak);
                    var sayfaSayisi = Math.floor(kategoriler[i].sorular.length / 4);
                    for (var j = 0; j < (sayfaSayisi); j++) {
                        dizi.push(dizi[dizi.length - 1] + 4);
                    }
                    if (kategoriler[i].sorular.length % 4 != 0)
                        dizi.push(dizi[dizi.length - 1] + kategoriler[i].sorular.length % 4);
                    console.log(dizi);

                    for (let k = 0; k < dizi.length - 1; k++) {
                        var sorular = yeniDiv();
                        sorular.className = "dortSoru";
                        for (var x = dizi[k]; x < dizi[k + 1]; x++) {
                            var soruCont = yeniDiv();
                            soruCont.className = "birSoru";
                            var soru = yeniDiv();
                            soru.innerHTML = kategoriler[i].sorular[x].soru;
                            soruCont.appendChild(soru);
                            var cevaplarCont = yeniDiv();
                            cevaplarCont.className = "dortCevap";
                            cevaplarCont.id = "dortCevap_" + x;
                            for (var y = 0; y < kategoriler[i].sorular[x].cevaplar.length; y++) {
                                var c = document.createElement("button");
                                c.className = "soru_" + x;
                                c.innerText = kategoriler[i].sorular[x].cevaplar[y].cevap;
                                c.addEventListener("click", function () {
                                    temizle(x);
                                    this.style.backgroundColor = "green";
                                });
                                cevaplarCont.appendChild(c);
                            }
                            soruCont.appendChild(cevaplarCont);
                            sorular.appendChild(soruCont);
                        }
                        sayfalar.push(sorular);
                    }
                    console.log(sayfalar);

                }
            }
        }
        xhr.open("GET", "/Sinav/Sorular", true);
        xhr.send();

    }
    else {
        btn.style.display = "none";
    }
    var dakika = 1;
    var saniye = 60;
    var sureMs = (dakika + 1) * 1000 * 60;
    var ekran = document.getElementById("sinavEkrani");
    ekran.innerText = " ";
    var sablon = yeniDiv();
    var ortaKisim = yeniDiv();
    ortaKisim.id = "orta";
    sablon.id = "sablon";
    var ustKisim = yeniDiv();
    ustKisim.id = "ust";
    //ustKisim.innerText = ;
    let handle = setInterval(() => {
        var z = new Date();
        saniye--;
        ustKisim.innerText = "Kalan Süre:" + "Son " + dakika + "dakika " + saniye + " saniye";
        if (saniye == 0 && dakika == 0)
            window.location.href = "http://www.google.com";
        else if (saniye == 0) {
            saniye = 60;
            dakika--;


        }
    }, 1000);
    setTimeout(() => {
        clearInterval(handle);
    }, sureMs);

    var altKisim = yeniDiv();
    altKisim.id = "alt";
    var ileri = document.createElement("button");
    ileri.innerText = "İLERİ";
    ileri.className = "yon";
    ileri.addEventListener("click", function () {
        if (index != sayfalar.length - 1)
            index++;
        ortaKisim.innerText = " ";
        ortaKisim.appendChild(sayfalar[index]);
        console.log(index);
    });
    var geri = document.createElement("button");
    geri.innerText = "GERİ";
    geri.className = "yon";
    geri.addEventListener("click", function () {
        if (index != 0)
            index--;
        ortaKisim.innerText = " ";
        ortaKisim.appendChild(sayfalar[index]);
        console.log(index);
    });
    altKisim.innerText = " ";
    altKisim.appendChild(geri);
    altKisim.appendChild(ileri);
    ortaKisim.innerText = " ";
    ortaKisim.appendChild(sayfalar[index]);
    sablon.appendChild(ustKisim);
    sablon.appendChild(ortaKisim);
    sablon.appendChild(altKisim);
    ekran.appendChild(sablon);
}


function yeniDiv() {
    var div = document.createElement("div");
    div.className = "form-group";
    return div;
}

function temizle(x) {
    var cevaplar = document.getElementsByClassName(".soru_"+x);
    console.log(cevaplar.length+" x:"+x);
    for (var b = 0; b < cevaplar.length; b++) {
        cevaplar[b].style.backgroundColor = "white";
    }
}