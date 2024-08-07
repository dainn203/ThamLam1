#include <stdio.h>

// Hàm tìm số lượng ít nhất các đồng xu cần thiết để đổi số tiền n
void doiTien(int coins[], int m, int n) {
	int count = 0;

	// Sắp xếp các mệnh giá đồng xu theo thứ tự giảm dần
	for (int i = 0; i < m - 1; i++) {
		for (int j = i + 1; j < m; j++) {
			if (coins[i] < coins[j]) {
				int temp = coins[i];
				coins[i] = coins[j];
				coins[j] = temp;
			}
		}
	}

	printf("Cac dong xu duoc chon:\n");
	for (int i = 0; i < m; i++) {
		while (n >= coins[i]) {
			n -= coins[i];
			count++;
			printf("%d ", coins[i]);
		}
	}
	printf("\nTong so dong xu duoc su dung: %d\n", count);
}

int main() {
	int coins[] = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 2000 };
	int m = sizeof(coins) / sizeof(coins[0]);
	int n = 289; // Số tiền cần đổi

	printf("So tien can doi: %d\n", n);
	doiTien(coins, m, n);

	return 0;
}
