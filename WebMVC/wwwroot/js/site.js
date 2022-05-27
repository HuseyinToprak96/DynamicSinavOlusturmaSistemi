 //ARRAYLER
    // var Sinav = new Sinav()
    var Kategoriler = [];
    //CLASLARR
    class Kategori {
        constructor(KategoriAdi) {
        this.KategoriAdi = KategoriAdi;

        }

    }
    //


    //AJAX
    $('#frmSinav').submit(function (e) {
        e.preventDefault();
    var formData = $(this).serialize();
    //alert(kategoriAdi);
    $.ajax({
        type: 'POST',
    url: '/Sinav/SinavEkle',
    data: formData,
    success: function (data) {
        console.log(data);
    kategoriEkleFormu();
            },
    error: function (error) {

    }
        });
    });
    function kategoriEkleFormu() {
        var place = document.getElementById("place");
    formKaldir();
    var form = document.createElement("form");
    form.id = "frmKategori";
    var div = divOlustur();
    var nesne = textboxOlustur();
    nesne.setAttribute("name", "KategoriAdi");
    nesne.placeholder = "Sinav Kategorisi Ekleyiniz.";
    div.appendChild(nesne);
    form.appendChild(div);
    var div1 = divOlustur();
    var ekle = butonOlustur('Ekle');
    ekle.addEventListener("click", function () {
            if (nesne.value != " ")
    var index = kategoriEkleMethod(nesne.value);
    liOlustur(nesne.value, index);
        });
    ekle.setAttribute("onclick", 'return false');
    div1.appendChild(ekle);
    form.appendChild(div1);
    var div2 = divOlustur();
    var devamEt = butonOlustur('Devam Et');
    devamEt.addEventListener("click", function () {
            //static instance da bulunan sinav kategorilerini çekerek dropdown a listeletme yapılacak
            var kategoriListesi = document.getElementById("kategoriListesi");
    kategoriListesi.remove();
    formKaldir();
    soruEkleFormuOlustur();
        });
    div2.appendChild(devamEt);

    form.appendChild(div2);
    place.appendChild(form);
    }
    function kategoriEkleMethod(str) {
        var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                //let result = JSON.parse(xhr.responseText
                var kat = new Kategori(str);
    Kategoriler.push(kat);
    // console.log(Kategoriler.length-1);
    console.log(parseInt(xhr.responseText));
    return (Kategoriler.length - 1)
            }
        }
    xhr.open("POST", "/Sinav/KategoriEkle?KategoriAdi=" + str, true);
    xhr.send();
    }

    function soruEkleFormuOlustur() {
        var place = document.getElementById("place");
    var form = document.createElement("form");
    form.id = "frmSoruEkle";
    var div = divOlustur();
    var select = document.createElement("select");
    select.name = "kategoriId"
    select.className = "form-control";
    for (var i = 0; i < Kategoriler.length; i++) {
            var opt = document.createElement("option");
    opt.value = i;
    opt.innerText = Kategoriler[i].KategoriAdi;
    select.appendChild(opt);
        }
    div.appendChild(select);
    var soruTipiDiv = divOlustur();
    var drp = document.createElement("select");
    drp.className = "form-control";
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
        let result = JSON.parse(xhr.responseText);
    var dizi = Array.from(result);
    for (var i = 0; i < dizi.length; i++) {
                    var op = document.createElement("option");
    op.value = i + 1;
    op.innerText = dizi[i];
    drp.appendChild(op);
                }
            }
        }
    xhr.open("Get", "/Sinav/SoruTipleri", true);
    xhr.send();
    var sTipi;
    drp.addEventListener("change", function () {
            var cevaplar = document.getElementsByClassName("rdCevap");
    sTipi = this.value;
    var tip = "";
    if (this.value == 2)
    tip = "checkbox";
    else if (this.value == 1)
    tip = "radio";
    for (var i = 0; i < cevaplar.length; i++) {
        cevaplar[i].setAttribute("type", tip);
            }
        });
    soruTipiDiv.appendChild(drp);



    var div1 = divOlustur();
    var nesne = textboxOlustur();
    nesne.setAttribute("name", "soru");
    nesne.style.height = "80px";
    nesne.placeholder = "Soru giriniz.";
    div1.appendChild(nesne);
    var cevapDivi = divOlustur();
    cevapDivi.id = "cevaplar";
    var rdA = radioButtonOlustur('A');
    var a = cevapOlustur('A');
    var divA = divOlustur();
    divA.appendChild(rdA);
    divA.appendChild(a);
    cevapDivi.appendChild(divA);
    var rdB = radioButtonOlustur('B');
    var b = cevapOlustur('B');
    var divB = divOlustur();
    divB.appendChild(rdB)
    divB.appendChild(b);
    cevapDivi.appendChild(divB);
    var rdC = radioButtonOlustur('A');
    var c = cevapOlustur('C');
    var divC = divOlustur();
    divC.appendChild(rdC);
    divC.appendChild(c);
    cevapDivi.appendChild(divC);
    var rdD = radioButtonOlustur('D');
    var d = cevapOlustur('D');
    var divD = divOlustur();
    divD.appendChild(rdD);
    divD.appendChild(d);
    cevapDivi.appendChild(divD);

    var div2 = divOlustur();
    var ekle = butonOlustur('Ekle');
    ekle.setAttribute("onclick", 'return false');
    div2.appendChild(ekle);
    ekle.addEventListener("click", function () {
        soruEkleMethod(select.value, nesne.value, sTipi);
    cevapEkleMethod(select.value, indis, a.value, rdA.checked);
    cevapEkleMethod(select.value, indis, b.value, rdB.checked);
    cevapEkleMethod(select.value, indis, c.value, rdC.checked);
    cevapEkleMethod(select.value, indis, d.value, rdD.checked);
            //var dto = "[ 'soruTipi':" + sTipi + ",'soru':" + nesne.value +
            //    "'cevaplar:[{'cevap':" + a.value + "',dogruMu':" + rdA.checked + "}," +
            //    "{'cevap': " + b.value + "',dogruMu': " + rdB.checked + " }," +
            //    "{'cevap': " + c.value + "',dogruMu': " + rdC.checked + " }, " +
            //    "{'cevap': " + d.value + "',dogruMu': " + rdD.checked + " }, ]";
            //var xhr = new XMLHttpRequest();
            //xhr.open("POST", "/Sinav/SoruuEkle?soru=" + JSON.stringify(dto), true);
            //xhr.send();
        });

    var div3 = divOlustur();
    var devamEt = butonOlustur('Devam Et');
    devamEt.addEventListener("click", function () {
        formKaldir();
    sinavEkrani();
            //kullaniciAtama();
        });
    div3.appendChild(devamEt);
    form.appendChild(div);
    form.appendChild(soruTipiDiv);
    form.appendChild(div1);
    form.appendChild(cevapDivi);
    form.appendChild(div2);
    form.appendChild(div3);
    place.appendChild(form);
    }
    let indis=-1;
    function soruEkleMethod(katId, soru, soruTipi) {
        // var soru = new Soru(katId, soru);
        // console.log(katId);
        // alert(soruTipi + " kat:" + katId + " soru:" + soru);
        
        var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
        indis = xhr.responseText;
              //  console.log("indis soru ekle method:"+indis);
               // return indis;
            }
        }
    xhr.open("POST", "/Sinav/SoruEkle?soruTipi=" + soruTipi + "&katIndis=" + katId + "&soru=" + soru, true);
    xhr.send();
    }
    function cevapEkleMethod(katId, soruId, cevap, dogruMu) {
       
        var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
        console.log("İndis:" + soruId);
            }
        }
        xhr.open("POST", "/Sinav/CevapEkle?katIndis=" + katId + "&soruIndis=" + soruId + "&cevap=" + cevap + "&dogruMu=" + dogruMu, true);
    xhr.send();
    }
    function kullaniciAtama() {
            var place = document.getElementById("place");

    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
        //let result = JSON.parse(xhr.responseText);
        //var dizi = JSON.from(result);
        //for (var i = 0; i < dizi.length; i++) {

        //}
        console.log(xhr.responseText);
    var table = document.createElement("table");
    var tr1 = document.createElement("tr");
    var td1 = document.createElement("td");
    td1.innerText = "Numarası";
    var td2 = document.createElement("td");
    td2.innerText="Adı Soyadı"
    var td3 = document.createElement("td");
    td3.innerText = "Sinava Ekle";
    tr1.appendChild(td1);
    tr1.appendChild(td2);
    tr1.appendChild(td3);
    var tr = document.createElement("tr");
    var td1 = document.createElement("td");
    td1.innerText = xhr.responseText;
    var td2 = document.createElement("td");
    td2.innerText = xhr.responseText;
    var td3 = document.createElement("td");
    var rb = document.createElement("input");
    rb.setAttribute("type", "radio");
    td3.appendChild(rb);
    tr.appendChild(td1);
    tr.appendChild(td2);
    tr.appendChild(td3);
    table.appendChild(tr1);
    table.appendChild(tr);
    place.appendChild(table);
                }
            }
    xhr.open("POST", "/Kullanici/Liste", true);
    xhr.send();
    }
    var kategoriIndis = -1;
    const tutucu = [];
    let ind = 0;
    function sinavEkrani() {
        tutucu.push(1);
    var place = document.getElementById("place");
    var sayfaNumarasi=0;
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
        let result = JSON.parse(xhr.responseText);
    var kategoriler = Array.from(result.kategoriler);
    for (var i = 0; i < kategoriler.length; i++) {
        tutucu.push(kategoriler[i].sorular.length + 1 + tutucu[tutucu.length - 1]);
                    //Kategori geçiş sayfalarını tutar
                }
    console.log(kategoriler);
    console.log(tutucu);
    var cont = divOlustur();
    cont.id = "cont";
    var ust = divOlustur();
    ust.id = "ustCont";
    var alt = divOlustur();
    alt.id = "altCont";
    var butonlar = divOlustur();
    butonlar.id = "yonButonlari";
    var sinavKategorisi = divOlustur();
    sinavKategorisi.innerText = "İl genel Meclisi İlköğretim Okulu 1. Sınıf 1. Dönem ";
    var ustKisim = divOlustur();
    ustKisim.id = "ustKisim";
    var sinavAdi = divOlustur();
    sinavAdi.innerText ="Sinav Adi:"+ result.sinavAdi;
    sinavAdi.id = "sinavAdiKismi";
    var aciklama = divOlustur();
    aciklama.innerText = result.aciklama;
    aciklama.id = "aciklamaKismi";
    var gecmeNotu = divOlustur();
    gecmeNotu.innerText ="Geçme Notu:"+ result.gecmeNotu;
    gecmeNotu.id = "gecmeNotuKismi";
    var sure = divOlustur();
    sure.innerText ="Sınav Süresi:"+ result.sure;
    sure.id = "sureKismi";
    var btnDiv = divOlustur();
    var geri = document.createElement("button");
    geri.className = "yon";
    geri.innerText = "GERİ";
    geri.disabled = true;
    geri.addEventListener("click", function () {
        sayfaNumarasi = parseInt(sayfaNumarasi) - 1;
    // alert(sayfaNumarasi);

    if (tutucu.includes(sayfaNumarasi)) {
        ind = tutucu.indexOf(sayfaNumarasi);
                    }
    sayfa(sayfaNumarasi, kategoriler[ind]);
    if (sayfaNumarasi == 0)
    geri.disabled = true;
                });

    var ileri = document.createElement("button");
    ileri.className = "yon";
    ileri.innerText = "İLERİ";
    ileri.addEventListener("click", function () {
      
    var ind = 0;
    if (tutucu.includes(sayfaNumarasi)) {
        ind = tutucu.indexOf(sayfaNumarasi);
                    }
        if (sayfaNumarasi < tutucu[tutucu.length - 1]) {
            sayfaNumarasi = parseInt(sayfaNumarasi) + 1;
        sayfa(sayfaNumarasi, kategoriler[ind]);
                    }

    // alert(sayfaNumarasi);
    geri.disabled = false;
                });

    btnDiv.appendChild(geri);
    btnDiv.appendChild(ileri);
    butonlar.appendChild(btnDiv);
    ustKisim.appendChild(sinavAdi);
    ustKisim.appendChild(gecmeNotu);
    ustKisim.appendChild(sure);
    ust.appendChild(sinavKategorisi);
    ust.appendChild(ustKisim);
    alt.appendChild(aciklama);
    cont.appendChild(ust);
    cont.appendChild(alt);
    cont.appendChild(butonlar);
    place.appendChild(cont);
            }
        }
    xhr.open("POST", "/Sinav/Guncelle", true);
    xhr.send();
    }
    function sayfa(no,kategori) {
        var cont = document.getElementById("altCont");
    cont.innerText = "Sayfa " + no + " Kategori:" + kategori.kategoriAdi;
    var xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
        let result = JSON.parse(xhr.responseText);
    var kategoriler = Array.from(result.kategoriler);
            }
        }
    xhr.open("POST","/Sinav/Kategori")

    }


    //ORTAK METHOD'LAR//
    function radioButtonOlustur(str) {
        var rad = document.createElement("input");
    rad.className = "rdCevap";
    rad.name = "cevap";
    rad.value = str;
    rad.setAttribute("type", "radio");
    return rad;
    }
    function optOlustur(str) {
        var opt = document.createElement("option");
    opt.value = str;
    opt.innerText = str;
    return opt;
    }

    function cevapOlustur(str) {

        var txt = textboxOlustur();
    txt.name = str;
    txt.className = "form-control";
    txt.placeholder = str + " şıkkını giriniz";
    txt.style.marginLeft = "3%";

    return txt;
    }

    function divOlustur() {
        var div = document.createElement("div");
    div.className = "form-group";
    return div;
    }
    function textboxOlustur() {
        var nesne = document.createElement("input");
    nesne.setAttribute("type", "text");
    nesne.className = "form-control";
    return nesne;
    }
    function butonOlustur(nick) {
        var btn = document.createElement("input");
    btn.setAttribute("type", "submit");
    btn.value = nick;
    btn.className = "btn btn-primary";
    return btn;
    }
    function formKaldir() {
        var frm = document.querySelector("#place form");
    frm.remove();
    }
    function liOlustur(str, id) {
        var li = document.createElement("li");
    li.innerText = str;
    li.id = "li_" + id;
    var btn = document.createElement("button");
    btn.innerText = "X";
    btn.addEventListener("click", function () {
        //  alert(id);
        console.log(Kategoriler);
    Kategoriler.splice(id, 1);
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Sinav/KategoriKaldir?indis=" + id, true);
    xhr.send();
    //delete Kategoriler[id];
    console.log(Kategoriler);
    var lii = document.getElementById("li_" + id);
    lii.remove();
            //statik kısımdan silmek için
        });
    li.appendChild(btn);
    var ul = document.getElementById("kategoriListesi");
    ul.appendChild(li);
    }
