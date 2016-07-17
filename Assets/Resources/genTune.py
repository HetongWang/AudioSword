import json
file = open("m01.txt","w")

tune_list = {}
tune_list["l"] = []

for i in xrange(1,50):
	pass
	item = {}
	item["mScore"] = 0
	item["mType"] = 0
	item["mVelocity"] = (1.0 * (i%3) + 2 )*2
	item["mDeparture_x"] = (i%5)*2 - 3
	item["mDeparture_y"] = (i%5 + 1) + 1
	item["mDeparture_z"] = (i%5 + 2) + 5
	item["mHitTime"] = item["mVelocity"]*300 + i*1000
	tune_list["l"].append(item)

file.write(json.dumps(tune_list))
