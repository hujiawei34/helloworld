import tkinter as tk
from time import strftime

def update_time():
    current_time = strftime('%H:%M:%S')  # Format: HH:MM:SS
    time_label.config(text=current_time)
    time_label.after(1000, update_time)  # Update every 1000ms (1 second)

# Create main window
root = tk.Tk()
root.title("Desktop Clock")

# Window settings for better desktop visibility
root.wm_attributes('-topmost', 1)  # Always on top
root.wm_attributes('-alpha', 0.8)  # Slightly transparent
root.overrideredirect(True)  # Remove title bar and borders

# Time display label
time_label = tk.Label(
    root,
    font=('Helvetica', 40, 'bold'),
    background='black',
    foreground='white'
)
time_label.pack()

# Position window in top-right corner
screen_width = root.winfo_screenwidth()
screen_height = root.winfo_screenheight()
x_position = screen_width - 300  # 300px from right edge
y_position = 20  # 20px from top edge
root.geometry(f'+{x_position}+{y_position}')

# Start time update loop
update_time()

# Run main application loop
root.mainloop()