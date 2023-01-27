# Entity Framework Core Isolations

Tarih: January 27, 2023 11:03 AM
Tip: KonuNotu

![ss1.png](Entity%20Framework%20Core%20Isolations%204fe432d1ad254717a4a0bfb0f6aefa95/ss1.png)

<aside>
🌟 Concurrency Effects

</aside>

### 1- Lost Updated

güncellemelerde bir işlemin ezilmesidir.

![ss2.png](Entity%20Framework%20Core%20Isolations%204fe432d1ad254717a4a0bfb0f6aefa95/ss2.png)

### 2- Dirty Read

güncellenen nesne commit edilmeden önce  okunursa dirty read olur.

![ss3.png](Entity%20Framework%20Core%20Isolations%204fe432d1ad254717a4a0bfb0f6aefa95/ss3.png)

### 3- Nonrepetable Read

data çekildikten sonra güncellenirse sonraki okumada ilki ile uyuşmaması

![ss4.png](Entity%20Framework%20Core%20Isolations%204fe432d1ad254717a4a0bfb0f6aefa95/ss4.png)

### 4- Phantom Read

ilk okuma ile ikinci okuma arasına yeni kayıt girer ise oluşur.

![Untitled](Entity%20Framework%20Core%20Isolations%204fe432d1ad254717a4a0bfb0f6aefa95/Untitled.png)