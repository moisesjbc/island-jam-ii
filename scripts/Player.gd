extends KinematicBody2D

# class member variables go here, for example:
export var speed = 100.0
var bullet_scene = preload("res://scenes/bullet.tscn")

func _ready():
	# Called every time the node is added to the scene.
	# Initialization here
	set_fixed_process(true)
	
func _fixed_process(delta):
	var move_vector = Vector2(0, 0)
	if Input.is_action_pressed("ui_left"):
		move_vector = Vector2(-1, 0)
	if Input.is_action_pressed("ui_right"):
		move_vector = Vector2(1, 0)
	if Input.is_action_pressed("shoot"):
		shoot()
	move(move_vector * speed * delta)
	
func shoot():
	var bullet = bullet_scene.instance()
	bullet.set_pos(get_pos() + Vector2(0, -40.0))
	get_tree().get_root().add_child(bullet)
	