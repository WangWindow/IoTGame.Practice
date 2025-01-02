import sqlite3
import csv

def import_lite_to_db():
    conn = sqlite3.connect("traffic.db")
    c = conn.cursor()

    # 创建 history 表
    c.execute('''
        CREATE TABLE IF NOT EXISTS history (
            road INTEGER,
            date TEXT,
            flow REAL,
            PRIMARY KEY(road, date)
        )
    ''')

    # 创建 future 表
    c.execute('''
        CREATE TABLE IF NOT EXISTS future (
            road INTEGER,
            date TEXT,
            flow REAL,
            PRIMARY KEY(road, date)
        )
    ''')

    with open('lite.csv', 'r', encoding='utf-8') as f:
        reader = csv.reader(f)
        header = next(reader)  # 跳过表头
        rows = list(reader)

        # 前 360 条数据存入 history 表
        for row in rows[:360]:
            date_value = row[0]
            for i in range(20):
                c.execute(
                    'INSERT OR IGNORE INTO history (road, date, flow) VALUES (?, ?, ?)',
                    (i, date_value, row[i+1])
                )

        # 后 120 条数据存入 future 表
        for row in rows[360:]:
            date_value = row[0]
            for i in range(20):
                c.execute(
                    'INSERT OR IGNORE INTO future (road, date, flow) VALUES (?, ?, ?)',
                    (i, date_value, row[i+1])
                )

    conn.commit()
    conn.close()

if __name__ == '__main__':
    import_lite_to_db()
