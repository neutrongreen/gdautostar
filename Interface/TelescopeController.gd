extends Control


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
onready var telescope = $GDSerial

onready var screen : RichTextLabel = $PanelContainer/VBoxContainer/MarginContainer/PanelContainer/ScreenText
onready var port_name : TextEdit = $PanelContainer/VBoxContainer/Buttons/GridContainer/HBoxContainer/TextEdit

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func open_port():
	telescope.PortName = port_name.text
	telescope.ConnectSerial()
	
	update_screen()

func update_screen():
	#get display string
	telescope.Write(":ED#")
	yield(get_tree().create_timer(1), "timeout")
	screen.text =  telescope.Read()
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
func command(cmd):
	telescope.Write(cmd)
	update_screen()
	
func command_no_mirror(cmd):
	telescope.Write(cmd)
