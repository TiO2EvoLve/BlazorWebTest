(function () {
    window.startSakura = function () {
        const numFlakes = 15; // 花瓣密度
        const flakes = [];
        const body = document.body;
        const canvas = document.createElement("canvas");
        const ctx = canvas.getContext("2d");
        let width = window.innerWidth;
        let height = window.innerHeight;

        canvas.style.position = "fixed";
        canvas.style.top = 0;
        canvas.style.left = 0;
        canvas.style.pointerEvents = "none";
        canvas.style.zIndex = 9999;
        canvas.width = width;
        canvas.height = height;
        body.appendChild(canvas);

        window.addEventListener("resize", () => {
            width = window.innerWidth;
            height = window.innerHeight;
            canvas.width = width;
            canvas.height = height;
        });

        const img = new Image();
        img.src = "/images/sakura.png"; // 樱花图片路径

        function Flake() {
            // x 允许在屏幕右延伸20%范围生成
            this.x = Math.random() * width * 1.4 + width * 0.2;
            this.y = Math.random() * (-height * 0.2); // 稍微在视口上方生成
            this.size = Math.random() * 30 + 20;
            // speedX 范围增大，允许更小的水平速度
            this.speedX = Math.random() * 2 + 0.2; // 0.2~2.2，部分花瓣斜率更小
            this.speedY = Math.random() * 1.5 + 0.5; // 0.5~2.0，垂直速度更大
            this.swing = Math.random() * 0.5;
            this.rotation = Math.random() * 360;
            this.rotationSpeed = Math.random() * 2 - 1;
        }

        Flake.prototype.update = function () {
            this.x -= this.speedX;
            this.y += this.speedY;
            this.x += Math.sin(this.y / 50) * this.swing;
            this.rotation += this.rotationSpeed;

            if (this.x < -width * 0.2 - 50 || this.x > width * 1.2 + 50 || this.y > height) {
                // 重置到顶端，x 也允许超出屏幕左右
                this.x = Math.random() * width * 1.4 - width * 0.2;
                this.y = Math.random() * (-height * 0.2);
                this.size = Math.random() * 30 + 20;
                // 重新赋值速度，保持分布
                this.speedX = Math.random() * 2 + 0.2;
                this.speedY = Math.random() * 1.5 + 0.5;
                this.rotation = Math.random() * 360;
            }
        };

        for (let i = 0; i < numFlakes; i++) {
            flakes.push(new Flake());
        }

        function draw() {
            ctx.clearRect(0, 0, width, height);
            flakes.forEach(flake => {
                ctx.save();
                ctx.translate(flake.x, flake.y);
                ctx.rotate((flake.rotation * Math.PI) / 180);
                ctx.drawImage(img, -flake.size / 2, -flake.size / 2, flake.size, flake.size);
                ctx.restore();
                flake.update();
            });
            requestAnimationFrame(draw);
        }

        img.onload = draw;
    };
})();
